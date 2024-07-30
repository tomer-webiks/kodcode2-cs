using Microsoft.EntityFrameworkCore;
using MyFriends2.Models;

namespace MyFriends2.DataLayer
{
    public class Context:DbContext
    {
        public Context(string ConnectionString):base(GetOptions(ConnectionString))
        {
            Database.EnsureCreated();
            if (Friends.Count() == 0) Seed();
        }

        //פונקציה לזריעת מסד הנתונים בפעם הראשונה
        private void Seed()
        {
            Friend friend = new Friend
            {
                FirstName = "שילה",
                LastName = "כהן",
                Email = "m@mail.com",
                Phone = "052354"
            };
            Friends.Add(friend);//הוספה לטבלה
            SaveChanges(); //שמירת שינויים במסד נתונים
        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Image> Images { get; set; }









        private static DbContextOptions GetOptions(string ConnectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }
    }
}
