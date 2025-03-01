using SocialNetwork.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendsView
    {
        public void Show(IEnumerable<User> friends)
        {
            Console.WriteLine("Ваши друзья: ");

            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас еще нет друзей");
                return;
            }

            friends.ToList().ForEach(friends =>
            {
                Console.WriteLine("Друг: {0} {1}", friends.FirstName, friends.LastName);
            });
        }
    }
}
