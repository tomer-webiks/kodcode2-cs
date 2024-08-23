using Microsoft.EntityFrameworkCore;
using MVCShoeShop.Models;

namespace MVCShoeShop.DAL
{
    public class ShoeDbContext : DbContext
    {
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ShoeDbContext(DbContextOptions<ShoeDbContext> options)
        : base(options)
        {
            // לוודא שהבסיס נתונים והטבלאות קיימות, אם לא תייצר את כולם ריקות
            Console.WriteLine("Database Exists: " + Database.EnsureCreated());
            
            // במידה ואין נתונים בטבלת נעליים, נזין כמה נתונים כדי שנוכל להתחיל
            if (Shoes?.Count() == 0)
            {
                Seed();
            }
        }

        private void Seed()
        {
            Shoe shoe1 = new Shoe()
            {
                Color = "Black",
                Size = 45,
                Images = []
            };
            
            Shoe shoe2 = new Shoe()
            {
                Color = "White",
                Size = 35,
                Images = []
            };

            Shoes.Add(shoe1);
            Shoes.Add(shoe2);

            SaveChanges();
        }
    }

}
