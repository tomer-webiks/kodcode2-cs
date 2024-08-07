using IronDome1.Models;
using IronDome1.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Diagnostics;
using IronDome1.ViewModels;

namespace IronDome1.Controllers
{
    public class IronDomeController : Controller
    {
        private readonly IronDomeDbContext _context;
        private readonly ILogger<IronDomeController> _logger;
        private static ConcurrentDictionary<string, CancellationTokenSource> _attacks = new ConcurrentDictionary<string, CancellationTokenSource>();

        public IronDomeController(IronDomeDbContext context, ILogger<IronDomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult ManageAttacks()
        {
            List<Attack>? attacks = _context.Attacks.ToList();
            return View(attacks);
        }

        public IActionResult NewAttack()
        {
            AttackViewModel avm = new AttackViewModel()
            {
                Attack = new Attack(),
                AttackTypes = Enum.GetValues(typeof(ATTACK_TYPE))
                                .Cast<ATTACK_TYPE>()
                                .Select(e => new SelectListItem
                                {
                                    Value = ((int)e).ToString(),
                                    Text = e.ToString()
                                }).ToList(),
                AttackSources = Enum.GetValues(typeof(ATTACK_SOURCE))
                                .Cast<ATTACK_SOURCE>()
                                .Select(e => new SelectListItem
                                {
                                    Value = ((int)e).ToString(),
                                    Text = e.ToString()
                                }).ToList()
            };

            return View(avm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAttack([FromForm] Attack attack)
        {
            _logger.LogInformation("CreateAttack called");

            // 1. Create in the DB
            attack.Date = DateTime.Now;
            attack.IsActive = false;
            _context.Attacks.Add(attack);
            await _context.SaveChangesAsync();

            return RedirectToAction("ManageAttacks");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("IronDome/StartAttack/{attackId}")]
        public async Task<IActionResult> StartAttack([FromRoute] int attackId)
        {
            // 2. Create a new Task/Thread
            var attackActiveId = Guid.NewGuid().ToString();
            Attack? attack = _context.Attacks.Find(attackId);
           
            if (attack != null)
            {
                attack.ActiveID = attackActiveId;
                await _context.SaveChangesAsync();
                var cts = new CancellationTokenSource();

                _attacks[attackActiveId] = cts;

                Task.Run(() => RunTask(attackActiveId, cts.Token), cts.Token);

                return RedirectToAction("ManageAttacks");
            } else
            {
                return RedirectToAction("ManageAttacks", new { Error = "Attack not found" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EndAttack(int attackId)
        {
            Attack? attack = _context.Attacks.Find(attackId);

            if (attack != null && _attacks.TryRemove(attack.ActiveID, out var cts))
            {
                cts.Cancel();
                Attack? a = _context.Attacks.Find(attackId);

                if (a != null)
                {
                    a.ActiveID = null;
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("ManageAttacks");
            }

            return NotFound("Attack not found");
        }

        private async Task RunTask(string attackId, CancellationToken token)
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
                    //await _hubContext.Clients.All.SendAsync("ReceiveProgress", message);
                }

                // Finished
                if (!token.IsCancellationRequested)
                {
                    //await _hubContext.Clients.All.SendAsync("ReceiveProgress", $"Attack {attackId} completed.");
                }
            }
            catch (TaskCanceledException)
            {
                //await _hubContext.Clients.All.SendAsync("ReceiveProgress", $"Attack {attackId} cancelled.");
            }
            finally
            {
                Attack? attack = _context.Attacks.Find(attackId);

                if (attack != null)
                {
                    attack.ActiveID = null;
                    await _context.SaveChangesAsync();
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
