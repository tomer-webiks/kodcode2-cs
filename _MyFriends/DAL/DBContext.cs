using Microsoft.EntityFrameworkCore;
using My_Friends_Img.Models;

namespace My_Friends_Img.DAL
{
    public class DBContext: DbContext
    {
        public DBContext(string connectionString ):base(GetOptions(connectionString)){
            Database.EnsureCreated();
            if (Friends.Count() == 0)
            {
                Seed();
            }
        }

        private void Seed()
        {
            Friend friend = new Friend
            {
                FirstName = "matanel",
                LastName = "vatkin",
                PhoneNumber = "0526193031",
                EmailAddress = "matanel@gmail.com"
            };
            Friends.Add(friend);
            SaveChanges();
        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Friend> Friends { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
