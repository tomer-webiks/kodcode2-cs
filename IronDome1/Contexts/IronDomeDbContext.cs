using IronDome1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IronDome1.Contexts
{
    public class IronDomeDbContext : DbContext
    {
        public DbSet<Attack> Attacks { get; set; }
        public DbSet<Defence> Defences { get; set; }

        public IronDomeDbContext(DbContextOptions<IronDomeDbContext> options)
        : base(options)
        {
            // לוודא שהבסיס נתונים והטבלאות קיימות, אם לא תייצר את כולם ריקות
            Console.WriteLine("Database Exists: " + Database.EnsureCreated());
        }
    }

}
