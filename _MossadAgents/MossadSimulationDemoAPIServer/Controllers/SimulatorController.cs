using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;
using MossadSimulationDemoAPIServer.ViewModels;
using MossadSimulationDemoAPIServer.Models;
using MossadSimulationDemoAPIServer.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using MossadSimulationDemoAPIServer.Middlewares;

namespace MossadSimulationDemoAPIServer.Controllers
{
    [ApiController]
    public class SimulatorController : ControllerBase
    {
        private static int _targetId = 1;
        private static int _agentId = 1;

        private readonly ILogger<SimulatorController> _logger;
        private readonly IGridService _gridService;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public SimulatorController(
            IConfiguration configuration,
            IGridService gridService,
            IAuthService authService,
            ILogger<SimulatorController> logger)
        {
            _gridService = gridService;
            _logger = logger;
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        [Route("/login")]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
            string token = null;
            try
            {
                token = _authService.Login(loginViewModel.Id);
                if (token == null)
                {
                    // Return a 401 Unauthorized response if login fails
                    return Unauthorized("Login failed: Invalid credentials.");
                } else
                {
                    return new JsonResult(new { token = token });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult($"Error {ex.Message}");
            }

        }

        [HttpPost]
        [Route("/agents")]
        [RequiresAuth]
        public IActionResult CreateAgent([FromBody] Agent agent)
        {
            try
            {
                agent.Id = _agentId++;
                _gridService.Agents.Add(agent);
                return new JsonResult(new { id = agent.Id });
            }
            catch (Exception ex)
            {
                return new JsonResult($"Error {ex.Message}");
            }
        }

        [HttpPut]
        [Route("/agents/{id}/pin")]
        [RequiresAuth]
        public IActionResult PinAgent(int id, [FromBody] LocationViewModel location)
        {
            int agentIndex = _gridService.Agents.FindIndex(a => a.Id == id);
            if (agentIndex != -1)
            {
                _gridService.Agents[agentIndex].Location.X = location.X;
                _gridService.Agents[agentIndex].Location.Y = location.Y;
            }

            return new NoContentResult();
        }

        [HttpPut]
        [Route("/agents/{id}/move")]
        [RequiresAuth]
        public IActionResult MoveAgent(int id, [FromBody] DirectionViewModel direction)
        {
            LocationViewModel shift = DirectionViewModel.ToLocation(direction);
            int agentIndex = _gridService.Agents.FindIndex(a => a.Id == id);
            int x = _gridService.Agents[agentIndex].Location.X += shift.X;
            int y = _gridService.Agents[agentIndex].Location.Y += shift.Y;

            if (agentIndex != -1 && x >= 0 && x < _gridService.MaxMatrixX && y >= 0 && y < _gridService.MaxMatrixY)
            {
                _gridService.Agents[agentIndex].Location.X = x;
                _gridService.Agents[agentIndex].Location.Y = y;
            }

            return new NoContentResult();
        }

        [HttpPost]
        [Route("/targets")]
        [RequiresAuth]
        public IActionResult CreateTarget([FromBody] Target target)
        {
            target.Id = _targetId++;
            _gridService.Targets.Add(target);
            return new JsonResult(new { id = target.Id });
        }

        [HttpPut]
        [Route("/targets/{id}/pin")]
        [RequiresAuth]
        public IActionResult PinTarget(int id, [FromBody] LocationViewModel location)
        {
            int targetIndex = _gridService.Targets.FindIndex(t => t.Id == id);
            if (targetIndex != -1)
            {
                _gridService.Targets[targetIndex].Location.X = location.X;
                _gridService.Targets[targetIndex].Location.Y = location.Y;
            }

            return new NoContentResult();
        }

        [HttpPut]
        [Route("/targets/{id}/move")]
        [RequiresAuth]
        public IActionResult MoveTarget(int id, [FromBody] DirectionViewModel direction)
        {
            LocationViewModel shift = DirectionViewModel.ToLocation(direction);
            int targetIndex = _gridService.Targets.FindIndex(t => t.Id == id);
            int x = _gridService.Targets[targetIndex].Location.X += shift.X;
            int y = _gridService.Targets[targetIndex].Location.Y += shift.Y;

            if (targetIndex != -1 && x >= 0 && x < _gridService.MaxMatrixX && y >= 0 && y < _gridService.MaxMatrixY)
            {
                _gridService.Targets[targetIndex].Location.X = x;
                _gridService.Targets[targetIndex].Location.Y = y;
            }

            return new NoContentResult();
        }

        [HttpPost]
        [Route("/missions/update")]
        [RequiresAuth]
        public IActionResult UpdateMissions()
        {
            return new JsonResult("");
        }
    }
}