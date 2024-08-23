using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;

namespace MossadSimulationDemoAPIServer.Controllers
{
    [ApiController]
    public class SimulatorController : ControllerBase
    {
        private static int _targetId = 1;
        private static int _agentId = 1;

        private readonly ILogger<SimulatorController> _logger;

        public SimulatorController(ILogger<SimulatorController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/agents")]
        public IActionResult CreateAgent([FromBody] Agent agent)
        {
            try
            {
                Console.WriteLine($"- POST /agents -- {JsonSerializer.Serialize(agent)}");
                var result = new { id = _agentId++ };
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult($"Error {ex.Message}");
            }
        }

        [HttpPut]
        [Route("/agents/{id}/pin")]
        public IActionResult PinAgent(int id, [FromBody] Location location)
        {
            Console.WriteLine($"- PUT /agents/{id}/pin -- {location.X}:{location.Y}");
            var result = new { id = _agentId++ };
            return new JsonResult(result);
        }

        [HttpPut]
        [Route("/agents/{id}/move")]
        public IActionResult MoveAgent(int id, [FromBody] DirectionName direction)
        {
            Console.WriteLine($"- PUT /agents/{id}/move -- {JsonSerializer.Serialize(direction)}");
            var result = new { id = _agentId++ };
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("/targets")]
        public IActionResult CreateTarget([FromBody] Target target)
        {
            Console.WriteLine($"- POST /targets -- {JsonSerializer.Serialize(target)}");
            var result = new { id = _targetId++ };
            return new JsonResult(result);
        }

        [HttpPut]
        [Route("/targets/{id}/pin")]
        public IActionResult PinTarget(int id, [FromBody] Location location)
        {
            Console.WriteLine($"- PUT /agents/{id}/pin -- {location.X}:{location.Y}");
            var result = new { id = _agentId++ };
            return new JsonResult(result);
        }

        [HttpPut]
        [Route("/targets/{id}/move")]
        public IActionResult MoveTarget(int id, [FromBody] DirectionName direction)
        {
            Console.WriteLine($"- PUT /targets/{id}/move -- {JsonSerializer.Serialize(direction)}");
            var result = new { id = _agentId++ };
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("/missions/update")]
        public IActionResult UpdateMissions()
        {
            Console.WriteLine($"- POST /missions/update");
            return new JsonResult("");
        }
    }

    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Agent
    {
        public string Nickname { get; set; }
        public string PhotoUrl { get; set; }
    }

    public class Target
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string PhotoUrl { get; set; }
    }

    public class DirectionName
    {
        public string Direction { get; set; }
    }
}
