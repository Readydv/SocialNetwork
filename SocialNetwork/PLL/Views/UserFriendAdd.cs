using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendAdd
    {
        UserService userService;
        FriendService friendService;

        public UserFriendAdd (UserService userService, FriendService friendService)
        {
            this.userService = userService;
            this.friendService = friendService;
        }

        public void Show(User user)
        {

                var friendData = new FriendData();

                Console.Write("Введите почтовый адрес вашего друга: ");
                friendData.FriendEmail = Console.ReadLine();

                friendData.UserId = user.Id;
            try
            {
                friendService.AddFriend(friendData);
                SuccessMessage.Show("Поздравляю! Вы теперь друзья!");
            }
            catch (UserNotFoundException)
            {
                AllertMessage.Show("Такого пользователя нет!");
            }
            catch (Exception)
            {
                AllertMessage.Show("Произошла ошибка при добавлении в друзья!");
            }
        }
    }
}
