using System.Text.Json;
using System.Text;

namespace MossadCommandCenter_Tomer.Services
{
    public class AgentService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AgentService> _logger;
        private readonly Random _random = new Random();

        private readonly int _maxAgents = 2;
        private readonly int _maxTargets = 2;
        private readonly int _activeAgents = 0;
        private readonly int _activeTargets = 0;

        private readonly int _syncInterval = 5;

        private readonly int _maxMatrixX = 1000;
        private readonly int _maxMatrixY = 1000;

        private readonly int _minRandomDelay = 5;
        private readonly int _maxRandomDelay = 15;

        // Constructor with DI for HttpClient and ILogger
        public AgentService(HttpClient httpClient, ILogger<AgentService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        // Method to start the service
        public void Start()
        {
            // -- Create new objects + Random pin --
            //Task.Run(async () => await GenerateAgentsAsync());
            Task.Run(async () => await GenerateTargetsAsync());

            // -- Move objects --
            Task.Run(async () => await GenerateTargetsAsync());

            // -- Sync Missions --
            //Task.Run(async () => await SyncMissionsAsync());
        }

        // Method to generate threats periodically
        private async Task GenerateTargetsAsync()
        {
            while (true)
            {
                // Create a fake target
                var target = new
                {
                    Location = new { X = _random.Next(_maxMatrixX), Y = _random.Next(_maxMatrixY) },
                    Name = "Muhammad",
                    Position = "Terrorist",
                    PhotoUrl = "http://",
                };

                // Serialize the threat to JSON
                var content = new StringContent(
                    JsonSerializer.Serialize(target),
                    Encoding.UTF8,
                    "application/json");

                // Send the POST request to create a threat
                try
                {
                    // 1. POST call
                    Console.WriteLine($"Target '{target.Name}' created.");
                    //var response = await _httpClient.PostAsync("/api/threats", content);
                    //response.EnsureSuccessStatusCode();
                    //_logger.LogInformation("Target created successfully.");

                    // 2. PUT PIN call
                    Console.WriteLine($"Target '{target.Name}' pinned at {target.Location.X}:{target.Location.Y}.");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Failed to create threat: {ex.Message}");
                }

                // Wait for a random period before generating the next threat
                await Task.Delay(TimeSpan.FromSeconds(_random.Next(_minRandomDelay, _maxRandomDelay)));
            }
        }
    }
}
