
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using MVCShopSimple.Models;

namespace MVCShopSimple.DAL
{
    public class FriendDbContext : DbContext
    {
        private static string _connectionString = "server = DESKTOP-3JPK806\\SQLEXPRESS;initial catalog=MySimpleShop; user id=sa; password=1234;TrustServerCertificate=Yes";
        public FriendDbContext(string ConnectionString) : base(GetOptions())
        {
            Database.EnsureCreated();
            if (Users?.Count() == 0) Seed();
        }

        //פונקציה לזריעת מסד הנתונים בפעם הראשונה
        private void Seed()
        {
            User friend = new User
            {
                UserId = 1233,
                Name = "תומר שגיא"
            };
            Users.Add(friend);//הוספה לטבלה
            SaveChanges(); //שמירת שינויים במסד נתונים
        }

        public DbSet<User> Users { get; set; }

        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), _connectionString).Options;
        }
    }
}
