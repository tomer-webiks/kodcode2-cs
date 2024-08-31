using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace MossadSimulationServer.Services
{
    public enum AUTH_TOKEN_TYPE
    {
        NONE,
        BODY,
        HEADER
    }

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
        private int _missionCounter = 1;

        private int _maxMatrixX = 25;
        private int _maxMatrixY = 25;

        private readonly int _minRandomDelay = 5;
        private readonly int _maxRandomDelay = 15;
        private int _maxMoves = 100;
        private int _agentMoveCounter = 0;
        private int _targetMoveCounter = 0;
        private int _syncDelay = 1;
        private int _moveDelay = 3;

        // Authentication
        private AUTH_TOKEN_TYPE _authTokenType = AUTH_TOKEN_TYPE.HEADER; // off 
        private static string? _token = null;
        private readonly int _loginAttempts = 3;
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
            _maxAgents = props.ContainsKey("maxAgents") ? props["maxAgents"] : _maxAgents;
            _maxTargets = props.ContainsKey("maxTargets") ? props["maxTargets"] : _maxTargets;
            _authTokenType = props.ContainsKey("authTokenType") ? (AUTH_TOKEN_TYPE)props["authTokenType"] : _authTokenType;
        }

        // Method to start the service
        public async Task Start()
        {
            // -- LOGIN and CHECK TOKEN --
            if (_authTokenType != AUTH_TOKEN_TYPE.NONE)
            {
                bool isLoggedIn = await Auth();
                if (!isLoggedIn)
                {
                    Console.WriteLine("Couldn't Login.");
                    return;
                }
            }

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

        private async Task<bool> Auth()
        {
            int loginCounter = 0;
            while (loginCounter++ < _loginAttempts && _token == null)
            {
                Console.WriteLine($"Login Attempt {loginCounter}");
                var clientName = new { id = "SimulationServer"};

                try
                {
                    // Attempt to login
                    var response = await _httpClient.PostAsync("/login", ToJSON(clientName));

                    // Successful - return true
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var jsonResponse = JsonDocument.Parse(responseContent);
                        _token = jsonResponse.RootElement.GetProperty("token").GetString();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                await Task.Delay(TimeSpan.FromSeconds(_loginAttemptDelay));
            }

            return false;
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
                StringBuilder sb = new StringBuilder();

                try
                {
                    // POST it
                    sb.Append($"TARGET\t{("(" + _targetCounter++ + ")").PadRight(7)} {"POST".PadRight(5)} /targets -- {await ToJSON(target).ReadAsStringAsync()}");

                    var response = await SendHttpRequestAsync(HttpMethod.Post, "/targets", target);

                    // Handle response
                    response.EnsureSuccessStatusCode();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonDocument.Parse(responseContent);
                    targetId = jsonResponse.RootElement.GetProperty("id").GetInt32(); // or GetInt32() depending on the type
                    _targetIds.Add(targetId);
                    sb.Append("\t++ Created Successfully.");
                }
                catch (Exception ex)
                {
                    sb.AppendLine("\t-- Failed to Create.");
                    sb.Append(ex.Message);
                }
                Console.WriteLine(sb.ToString());


                // -- 2. Pin target
                if (targetId != -1)
                {
                    var location = new
                    {
                        x = _random.Next(_maxMatrixX),
                        y = _random.Next(_maxMatrixY)
                    };
                    sb.Clear();

                    try
                    {
                        // PUT it
                        sb.Append($"TARGET\t{("(" + targetId + ")").PadRight(7)} {"PUT".PadRight(5)} /targets/{targetId}/pin -- {await ToJSON(location).ReadAsStringAsync()}");
                        var response = await SendHttpRequestAsync(HttpMethod.Put, $"/targets/{targetId}/pin", location);
                        sb.Append("\t++ Pinned Successfully.");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("\t-- Failed to Pin.");
                        sb.Append(ex.Message);
                    }
                    Console.WriteLine(sb.ToString());
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
                StringBuilder sb = new StringBuilder();

                try
                {
                    // POST it
                    sb.Append($"AGENT\t{("(" + _agentCounter++ + ")").PadRight(7)} {"POST".PadRight(5)} /agents -- {await ToJSON(agent).ReadAsStringAsync()}");
                    var response = await SendHttpRequestAsync(HttpMethod.Post, "/agents", agent);

                    // Handle response
                    response.EnsureSuccessStatusCode();
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonDocument.Parse(responseContent);
                    agentId = jsonResponse.RootElement.GetProperty("id").GetInt32(); // or GetInt32() depending on the type
                    _agentIds.Add(agentId);
                    sb.Append("\t++ Created Successfully.");
                }
                catch (Exception ex)
                {
                    sb.AppendLine("\t-- Failed to Create.");
                    sb.Append(ex.Message);
                }
                Console.WriteLine(sb.ToString());


                // -- 2. Pin target
                if (agentId != -1)
                {
                    var location = new
                    {
                        x = _random.Next(_maxMatrixX),
                        y = _random.Next(_maxMatrixY)
                    };
                    sb.Clear();

                    try
                    {
                        // PUT it
                        sb.Append($"AGENT\t{("(" + agentId + ")").PadRight(7)} {"PUT".PadRight(5)} /agents/{agentId}/pin -- {await ToJSON(location).ReadAsStringAsync()}");
                        var response = await SendHttpRequestAsync(HttpMethod.Put, $"/agents/{agentId}/pin", location);
                        sb.Append("\t++ Pinned Successfully.");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("\t-- Failed to Pin.");
                        sb.Append(ex.Message);
                    }
                    Console.WriteLine(sb.ToString());
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
                    StringBuilder sb = new StringBuilder();

                    try
                    {
                        // PUT it
                        sb.Append($"AGENT\t{("(" + _agentIds[index] + ")").PadRight(7)} {"PUT".PadRight(5)} /agents/{_agentIds[index]}/move -- {await ToJSON(direction).ReadAsStringAsync()}");
                        var response = await SendHttpRequestAsync(HttpMethod.Put, $"/agents/{_agentIds[index]}/move", direction);
                        sb.Append("\t++ Moved Successfully.");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("\t-- Failed to Move.");
                        sb.Append(ex.Message);
                    }
                    Console.WriteLine(sb.ToString());

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
                    StringBuilder sb = new StringBuilder();

                    try
                    {
                        // PUT it
                        sb.Append($"TARGET\t{("(" + _targetIds[index] + ")").PadRight(7)} {"PUT".PadRight(5)} /targets/{_targetIds[index]}/move -- {await ToJSON(direction).ReadAsStringAsync()}");
                        var response = await SendHttpRequestAsync(HttpMethod.Put, $"/targets/{_targetIds[index]}/move", direction);
                        sb.Append("\t++ Moved Successfully.");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("\t-- Failed to Move.");
                        sb.Append(ex.Message);
                    }
                    Console.WriteLine(sb.ToString());

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
                    StringBuilder sb = new StringBuilder();

                    try
                    {
                        // PUT it
                        sb.Append($"MISSION\t{("(" + _missionCounter++ + ")").PadRight(7)} {"POST".PadRight(5)} /missions/update");
                        var response = await SendHttpRequestAsync(HttpMethod.Post, $"/missions/update", new {});
                        sb.Append("\t++ Updated Successfully.");
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("\t-- Failed to Update.");
                        sb.Append(ex.Message);
                    }
                    Console.WriteLine(sb.ToString());

                    // Wait for a random period before generating the next threat
                    await Task.Delay(TimeSpan.FromSeconds(_syncDelay));
                }
            }
        }

        private async Task<HttpResponseMessage> SendHttpRequestAsync(HttpMethod method, string url, object data)
        {
            var requestMessage = new HttpRequestMessage(method, url);

            // Add the JSON data to the request body
            if (method != HttpMethod.Get)
            {
                requestMessage.Content = ToJSON(data);
            }

            // Add the token either to the header or to the body based on the flag
            if (_authTokenType == AUTH_TOKEN_TYPE.HEADER)
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            }
            else if (_authTokenType == AUTH_TOKEN_TYPE.BODY) 
            {
                // Create a dictionary to hold the combined data
                var body = new Dictionary<string, object>();

                // Use reflection to "spread" the properties of the data object into the dictionary
                foreach (var property in data.GetType().GetProperties())
                {
                    body[property.Name] = property.GetValue(data);
                }

                // Add the token as a new property
                body["token"] = _token;
                requestMessage.Content = ToJSON(body);
            }

            // Send the request and return the response
            return await _httpClient.SendAsync(requestMessage);
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
