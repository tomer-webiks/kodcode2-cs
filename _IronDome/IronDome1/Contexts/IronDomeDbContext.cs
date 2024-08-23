using IronDome.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static IronDome.Models.Attack;

namespace IronDome.Contexts
{
    public class IronDomeDbContext : DbContext
    {
        public DbSet<Attack> Attacks { get; set; }
        public DbSet<Defence> Defences { get; set; }

        public DbSet<AttackType> AttackTypes { get; set; }
        public DbSet<AttackOrigin> AttackOrigins { get; set; }

        public IronDomeDbContext(DbContextOptions<IronDomeDbContext> options)
        : base(options)
        {
            // לוודא שהבסיס נתונים והטבלאות קיימות, אם לא תייצר את כולם ריקות
            Console.WriteLine("Database Exists: " + Database.EnsureCreated());

            if (AttackTypes?.Count() == 0 || AttackOrigins?.Count() == 0)
            {
                Seed();
            }
        }

        private async void Seed()
        {
            await AttackTypes.AddAsync(new AttackType { Name = "Balistic Missile", SpeedKMH = 18000 });
            await AttackTypes.AddAsync(new AttackType { Name = "Katbam", SpeedKMH = 300 });
            await AttackTypes.AddAsync(new AttackType { Name = "Rocket", SpeedKMH = 880 });

            await AttackOrigins.AddAsync(new AttackOrigin { Name = "Iran", DistanceKM = 1600 });
            await AttackOrigins.AddAsync(new AttackOrigin { Name = "Lebanon", DistanceKM = 50 });
            await AttackOrigins.AddAsync(new AttackOrigin { Name = "Iraq", DistanceKM = 1500 });
            await AttackOrigins.AddAsync(new AttackOrigin { Name = "Yemen", DistanceKM = 2377 });
            await AttackOrigins.AddAsync(new AttackOrigin { Name = "Gaza", DistanceKM = 70 });

            await SaveChangesAsync();
        }
    }

}
