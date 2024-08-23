using System.Text.Json;
using System.Text;

namespace MossadSimulationServer.Services
{
    public class SimulationServer
    {
        private readonly HttpClient _httpClient;
        private readonly Random _random = new Random();

        private readonly int _maxAgents = 3;
        private readonly int _maxTargets = 3;

        private int _agentCounter = 0;
        private List<int> _agentIds = new List<int>();
        private int _targetCounter = 0;
        private List<int> _targetIds = new List<int>();

        private int _maxMatrixX = 1000;
        private int _maxMatrixY = 1000;

        private readonly int _minRandomDelay = 5;
        private readonly int _maxRandomDelay = 15;
        private int _maxMoves = 100;
        private int _agentMoveCounter = 0;
        private int _targetMoveCounter = 0;
        private int _syncDelay = 3;
        private int _moveDelay = 10;

        // Authentication
        private static string _token = null;
        private readonly int _loginAttempts = 5;
        private readonly int _loginAttemptDelay = 5;

        private static readonly object[] agents = new[]
        {
            new { nickname = "Agent001", photoUrl = "https://randomuser.me/api/portraits/men/1.jpg" },
            new { nickname = "Agent002", photoUrl = "https://randomuser.me/api/portraits/women/2.jpg" },
            new { nickname = "Agent003", photoUrl = "https://randomuser.me/api/portraits/men/3.jpg" },
            new { nickname = "Agent004", photoUrl = "https://randomuser.me/api/portraits/women/4.jpg" },
            new { nickname = "Agent005", photoUrl = "https://randomuser.me/api/portraits/men/5.jpg" },
            new { nickname = "Agent006", photoUrl = "https://randomuser.me/api/portraits/women/6.jpg" },
            new { nickname = "Agent007", photoUrl = "https://randomuser.me/api/portraits/men/7.jpg" },
            new { nickname = "Agent008", photoUrl = "https://randomuser.me/api/portraits/women/8.jpg" },
            new { nickname = "Agent009", photoUrl = "https://randomuser.me/api/portraits/men/9.jpg" },
            new { nickname = "Agent010", photoUrl = "https://randomuser.me/api/portraits/women/10.jpg" }
        };

        private static readonly object[] targets = new[]
        {
            new { name = "Target001", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/men/11.jpg" },
            new { name = "Target002", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/women/12.jpg" },
            new { name = "Target003", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/men/13.jpg" },
            new { name = "Target004", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/women/14.jpg" },
            new { name = "Target005", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/men/15.jpg" },
            new { name = "Target006", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/women/16.jpg" },
            new { name = "Target007", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/men/17.jpg" },
            new { name = "Target008", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/women/18.jpg" },
            new { name = "Target009", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/men/19.jpg" },
            new { name = "Target010", position = "Terrorist", photoUrl = "https://randomuser.me/api/portraits/women/20.jpg" }
        };

        // Constructor with DI for HttpClient and ILogger
        public SimulationServer(HttpClient httpClient, Dictionary<string, int> props)
        {
            _httpClient = httpClient;
            _syncDelay = props.ContainsKey("syncDelay") ? props["syncDelay"] : _syncDelay;
            _moveDelay = props.ContainsKey("moveDelay") ? props["moveDelay"] : _moveDelay;
            _maxMoves = props.ContainsKey("maxMoves") ? props["maxMoves"] : _maxMoves;
            _maxMatrixX = props.ContainsKey("maxMatrixX") ? props["maxMatrixX"] : _maxMatrixX;
            _maxMatrixY = props.ContainsKey("maxMatrixY") ? props["maxMatrixY"] : _maxMatrixY;

            Console.WriteLine("XX: " +  _maxMoves + " | " + props["maxMatrixX"]);
        }

        // Method to start the service
        public void Start()
        {
            // -- LOGIN and CHECK TOKEN --
            //int loginCounter = 0;
            //while (loginCounter++ < _loginAttempts && _token == null)
            //{
            //    await Task.Delay(TimeSpan.FromSeconds(_loginAttemptDelay));
            //}

            // -- Create new objects + Random pin --
            List<Task> tasks = new List<Task>();

            tasks.Add(Task.Run(async () => await GenerateAgentsAsync()));
            tasks.Add(Task.Run(async () => await GenerateTargetsAsync()));

            // -- Move objects --
            tasks.Add(Task.Run(async () => await MoveAgentsAsync()));
            tasks.Add(Task.Run(async () => await MoveTargetsAsync()));

            // -- Sync Missions --
            tasks.Add(Task.Run(async () => await UpdateMissionsAsync()));

            Task.WaitAll(tasks.ToArray());
        }

        // Method to generate threats periodically
        private async Task GenerateTargetsAsync()
        {
            while (_targetCounter++ < _maxTargets)
            {
                var random = new Random();

                // -- 1. Create a target
                int targetId = -1;
                var target = targets[random.Next(targets.Length)];

                try
                {
                    // POST it
                    Console.WriteLine($"TARGET\t({_targetCounter})\t*\tPOST /targets -- {await ToJSON(target).ReadAsStringAsync()}");
                    var response = await _httpClient.PostAsync("/targets", ToJSON(target));

                    // Handle response
                    response.EnsureSuccessStatusCode();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonDocument.Parse(responseContent);
                    targetId = jsonResponse.RootElement.GetProperty("id").GetInt32(); // or GetInt32() depending on the type
                    _targetIds.Add(targetId);
                    Console.WriteLine($"TARGET\t({_targetCounter})\t +\t- Target {targetId} created Successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"TARGET\t({_targetCounter})\t\t- Failed to create Target {targetId}!");
                }


                // -- 2. Pin target
                if (targetId != -1)
                {
                    var location = new
                    {
                        x = _random.Next(_maxMatrixX),
                        y = _random.Next(_maxMatrixY)
                    };

                    try
                    {
                        // PUT it
                        Console.WriteLine($"TARGET\t({_targetCounter})\t*\tPUT /targets/{targetId}/pin -- {await ToJSON(location).ReadAsStringAsync()}");
                        var response = await _httpClient.PutAsync($"/targets/{targetId}/pin", ToJSON(location));
                        Console.WriteLine($"TARGET\t({_targetCounter})\t +\t- Target {targetId} pinned Successfully: [{location.x}:{location.y}]");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"TARGET\t({_targetCounter})\t\t- Failed to pin Target {targetId}: [{location.x}:{location.y}]!");
                    }
                }

                // Wait for a random period before generating the next threat
                await Task.Delay(TimeSpan.FromSeconds(_random.Next(_minRandomDelay, _maxRandomDelay)));
            }
        }

        // Method to generate threats periodically
        private async Task GenerateAgentsAsync()
        {
            var random = new Random();

            while (_agentCounter++ < _maxAgents)
            {
                // -- 1. Create a target
                int agentId = -1;
                var agent = agents[random.Next(agents.Length)];

                try
                {
                    // POST it
                    Console.WriteLine($"AGENT\t({_agentCounter})\t*\tPOST /agents -- {await ToJSON(agent).ReadAsStringAsync()}");
                    var response = await _httpClient.PostAsync("/agents", ToJSON(agent));

                    // Handle response
                    response.EnsureSuccessStatusCode();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonDocument.Parse(responseContent);
                    agentId = jsonResponse.RootElement.GetProperty("id").GetInt32(); // or GetInt32() depending on the type
                    _agentIds.Add(agentId);
                    Console.WriteLine($"AGENT\t({_agentCounter})\t +\t- Agent {agentId} created Successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"AGENT\t({_agentCounter})\t\t- Failed to create Agent {agentId}!");
                }


                // -- 2. Pin target
                if (agentId != -1)
                {
                    var location = new
                    {
                        x = _random.Next(_maxMatrixX),
                        y = _random.Next(_maxMatrixY)
                    };

                    try
                    {
                        // PUT it
                        Console.WriteLine($"AGENT\t({_agentCounter})\t*\tPUT /agents/{agentId}/pin -- {await ToJSON(location).ReadAsStringAsync()}");
                        var response = await _httpClient.PutAsync($"/agents/{agentId}/pin", ToJSON(location));
                        Console.WriteLine($"AGENT\t({_agentCounter})\t +\t- Agent {agentId} pinned Successfully: [{location.x}:{location.y}]");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"AGENT\t({_agentCounter})\t\t- Failed to pin Agent {agentId}: [{location.x}:{location.y}]!");
                    }
                }

                // Wait for a random period before generating the next threat
                await Task.Delay(TimeSpan.FromSeconds(_random.Next(_minRandomDelay, _maxRandomDelay)));
            }
        }

        private async Task MoveAgentsAsync()
        {
            int waitTicks = 5;
            while (waitTicks++ > 0 && _agentIds.Count == 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            while (_agentMoveCounter++ < _maxMoves)
            {
                // -- AGENTS --
                for (int index = 0; index < _agentIds.Count; index++)
                {
                    var direction = new
                    {
                        direction = RandomDirection()
                    };

                    try
                    {
                        // PUT it
                        Console.WriteLine($"AGENT\t({_agentCounter})\t*\tPUT /agents/{_agentIds[index]}/move -- {await ToJSON(direction).ReadAsStringAsync()}");
                        var response = await _httpClient.PutAsync($"/agents/{_agentIds[index]}/move", ToJSON(direction));
                        Console.WriteLine($"AGENT\t({_agentCounter})\t +\t- Agent {_agentIds[index]} moved Successfully: {direction.direction}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"AGENT\t({index})\t\t- Failed to move Agent {_agentIds[index]}: [{direction}]!");
                    }

                    // Wait for a random period before generating the next threat
                    await Task.Delay(TimeSpan.FromSeconds(_moveDelay));
                }
            }
        }

        private async Task MoveTargetsAsync()
        {
            int waitTicks = 5;
            while (waitTicks++ > 0 && _targetIds.Count == 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            while (_targetMoveCounter++ < _maxMoves)
            {

                // -- TARGETS --
                for (int index = 0; index < _targetIds.Count; index++)
                {
                    var direction = new
                    {
                        direction = RandomDirection()
                    };

                    try
                    {
                        // PUT it
                        Console.WriteLine($"TARGET\t({_agentCounter})\t*\tPUT /targets/{_targetIds[index]}/move -- {await ToJSON(direction).ReadAsStringAsync()}");
                        var response = await _httpClient.PutAsync($"/targets/{_targetIds[index]}/move", ToJSON(direction));
                        Console.WriteLine($"TARGET\t({_agentCounter})\t +\t- Target {_targetIds[index]} moved Successfully: {direction.direction}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"TARGET\t({index})\t\t- Failed to move Target {_targetIds[index]}: [{direction}]!");
                    }

                    // Wait for a random period before generating the next threat
                    await Task.Delay(TimeSpan.FromSeconds(_moveDelay));
                }
            }
        }

        private async Task UpdateMissionsAsync()
        {
            int waitTicks = 5;
            while (waitTicks++ > 0 && _targetIds.Count == 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
            }

            while (true)
            {

                // -- TARGETS --
                for (int index = 0; index < _targetIds.Count; index++)
                {
                    var direction = RandomDirection();

                    try
                    {
                        // PUT it
                        Console.WriteLine($"MISSION\t({_agentCounter})\t*\tPOST /missions/update");
                        var response = await _httpClient.PostAsync($"/missions/update", null);
                        Console.WriteLine($"MISSION\t({_agentCounter})\t +\t- Missions updated Successfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"MISSION\t({index})\t\t- Failed to update Missions!");
                    }

                    // Wait for a random period before generating the next threat
                    await Task.Delay(TimeSpan.FromSeconds(_syncDelay));
                }
            }
        }

        private static string RandomDirection()
        {
            string[] directions = { "n", "ne", "e", "se", "s", "sw", "w", "nw" };
            Random random = new Random();
            int index = random.Next(directions.Length);
            return directions[index];
        }

        private static StringContent ToJSON(object content)
        {
            return new StringContent(
                        JsonSerializer.Serialize(content),
                        Encoding.UTF8,
                        "application/json");
        }
    }
}
