
using Microsoft.EntityFrameworkCore;
using MVCShopSimple.Models;

namespace MVCShopSimple.DAL
{
    public class ShoeDbContext : DbContext
    {
        private static readonly string _connectionString = "server = DESKTOP-3JPK806\\SQLEXPRESS;initial catalog=MySimpleShop; user id=sa; password=1234;TrustServerCertificate=Yes";
        public ShoeDbContext() : base(GetOptions())
        {
            Database.EnsureCreated();

            // Initiative the DB if there are missing tables
            if (Shoes?.Count() == 0) Seed();
        }

        public DbSet<Shoe> Shoes { get; set; }

        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), _connectionString).Options;
        }

        //פונקציה לזריעת מסד הנתונים בפעם הראשונה
        private void Seed()
        {
            Shoe shoe = new Shoe()
            {
                Id = 1233,
                Color = "Black"
            };

            Shoes.Add(shoe);//הוספה לטבלה
            SaveChanges(); //שמירת שינויים במסד נתונים
        }
    }
}
