using MyFriends2.DataLayer;
using MyFriends2.Models;

namespace MyFriends2.Service
{
    public class FriendService : IFriendService
    {
        private readonly Context _context;

        public FriendService(Context context)
        {
            _context = context;
        }
        public List<Friend> GetFriends()
        {
            return _context.Friends.ToList();
        }
    }
}
