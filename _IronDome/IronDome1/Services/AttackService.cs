using IronDome.Contexts;
using IronDome.Models;
using IronDome.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace IronDome.Services
{
    public interface IAttackService
    {
        Task<bool> StartAttack(int attackId);
        Task<bool> InterceptAttack(int attackId);
    }

    public class AttackService : IAttackService
    {
        private readonly IHubContext<ChatHub> _chatHub;
        private readonly IronDomeDbContext _context;

        // TODO: Move to singleton
        private static ConcurrentDictionary<int, CancellationTokenSource> _attacks = new ConcurrentDictionary<int, CancellationTokenSource>();

        public AttackService(IHubContext<ChatHub> chatHub, IronDomeDbContext context)
        {
            _chatHub = chatHub;
            _context = context;
        }

        public async Task<bool> StartAttack(int attackId)
        {
            Attack? attack = await _context.Attacks.FindAsync(attackId);

            if (attack != null)
            {
                // 2. Update the attack's start time
                attack.StartTime = DateTime.Now;
                attack.IsActive = true;
                await _context.SaveChangesAsync();

                // 3. Create the CTS
                var cts = new CancellationTokenSource();
                _attacks[attackId] = cts;

                // 4. Start the threaded attack
                Task.Run(() => StartAttackTask(attack, cts.Token), cts.Token);

                return true;
            } else
            {
                return false;
            }
        }

        private async Task StartAttackTask(Attack attack, CancellationToken cancellationToken)
        {
            try
            {
                int elapsed = 0;
                while (elapsed < attack.TimeToImpact && !cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(2000, cancellationToken); // Wait for 2 seconds or cancel if requested
                    elapsed += 2;
                    var message = $"Attack {attack.ID} running for {elapsed} seconds.";
                    Console.WriteLine(message);
                    await _chatHub.Clients.All.SendAsync("ReceiveMessage", message);
                }

                // Finished
                if (!cancellationToken.IsCancellationRequested)
                {
                    //await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"Attack {attackId} completed.");
                }
            }
            catch (TaskCanceledException)
            {
                //await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"Attack {attackId} cancelled.");
            }
        }

        public async Task<bool> InterceptAttack(int attackId)
        {
            // 1. Find the Attack
            Attack? attack = await _context.Attacks.FindAsync(attackId);

            if (attack != null && _attacks.TryRemove(attackId, out var cts))
            {
                // 2. Update the IsActive flag
                attack.IsActive = false;
                await _context.SaveChangesAsync();

                cts.Cancel();
                return true;
            } else
            {
                return false;
            }
        }
    }

}
