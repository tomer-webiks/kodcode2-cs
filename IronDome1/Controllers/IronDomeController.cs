using IronDome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using IronDome.ViewModels;
using Microsoft.EntityFrameworkCore;
using IronDome.Hubs;
using IronDome.Services;
using IronDome.Contexts;

namespace IronDome.Controllers
{
    public class IronDomeController : Controller
    {
        private readonly ILogger<IronDomeController> _logger;
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly IAttackService _attackService;
        private readonly IronDomeDbContext _context;

        public IronDomeController(
            IHubContext<ChatHub> chatHub,
            IAttackService attackService,
            ILogger<IronDomeController> logger,
            IronDomeDbContext context)
        {
            _attackService = attackService;
            _chatHub = chatHub;
            _logger = logger;
            _context = context;
        }


        public IActionResult Chat()
        {
            var model = new ChatModel
            {
                Messages = new List<string>() // Initialize with empty list or actual data
            };

            return View(model);
        }


        public async Task<IActionResult> ManageAttacks()
        {
            List<Attack>? attacks = await _context.Attacks
                .Include(a => a.Type)
                .Include(a => a.Origin)
                .ToListAsync();

            return View(attacks);
        }

        [Route("IronDome/Attack/New")]
        public async Task<IActionResult> NewAttack()
        {
            List<AttackType> atList = _context.AttackTypes.ToList();
            List<AttackOrigin> aoList = _context.AttackOrigins.ToList();
            AttackViewModel avm = new AttackViewModel()
            {
                Attack = new Attack(),
                TypeSelectListItems = atList.Select(at =>
                    new SelectListItem { Value = at.Id.ToString(), Text = at.Name }).ToList(),
                OriginSelectListItems = aoList.Select(at =>
                    new SelectListItem { Value = at.Id.ToString(), Text = at.Name }).ToList()
            };

            return View(avm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAttack([FromForm] Attack attack)
        {
            _logger.LogInformation("CreateAttack called");

            // 1. Create in the DB
            attack.IsActive = false;
            _context.Attacks.Add(attack);
            await _context.SaveChangesAsync();

            return RedirectToAction("ManageAttacks");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("IronDome/Attack/{attackId}/Start")]
        public async Task<IActionResult> StartAttack([FromRoute] int attackId)
        {
            bool isStarted = await _attackService.StartAttack(attackId);
           
            if (isStarted)
            {
                return RedirectToAction("ManageAttacks");
            } else
            {
                return RedirectToAction("ManageAttacks", new { Error = "Attack not found" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("IronDome/Attack/{attackId}/Intercept")]
        public async Task<IActionResult> InterceptAttack([FromRoute] int attackId)
        {
            bool isIntercepted = await _attackService.InterceptAttack(attackId);

            if (isIntercepted)
            {
                return RedirectToAction("ManageAttacks");
            }
            else
            {
                return NotFound("Attack not found");
            }
        }

        private async Task ExecuteAttack(int attackId, CancellationToken token)
        {
            try
            {
                int elapsed = 0;
                while (elapsed < 120 && !token.IsCancellationRequested)
                {
                    await Task.Delay(2000, token); // Wait for 2 seconds or cancel if requested
                    elapsed += 2;
                    var message = $"Attack {attackId} running for {elapsed} seconds.";
                    Console.WriteLine(message);
                    await _chatHub.Clients.All.SendAsync("ReceiveMessage", message);
                }

                // Finished
                if (!token.IsCancellationRequested)
                {
                    //await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"Attack {attackId} completed.");
                }
            }
            catch (TaskCanceledException)
            {
                //await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"Attack {attackId} cancelled.");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
