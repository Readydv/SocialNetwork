﻿using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        UserService UserService;
        public UserMenuView(UserService userService) 
        {
            this.UserService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Входящие сообщения: {0}", user.IncomingMessages.Count());
                Console.WriteLine("Исходящие соообщения: {0}", user.OutcomingMessages.Count());

                Console.WriteLine("Просмотреть информацию о моем профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Посмотреть входящие сообщения (нажмите 5)");
                Console.WriteLine("Посмотреть исходящие сообщения (нажмие 6)");
                Console.WriteLine("Посмотреть список друзей (нажмите 7)");
                Console.WriteLine("Выйти из профиля (нажмите 8)");

                string keyValue = Console.ReadLine();

                if (keyValue == "8") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Program.userInfoView.Show(user);
                            break;
                        }
                    case "2":
                        {
                            Program.userDataUpdateView.Show(user);
                            break;
                        }
                    case "3":
                        {
                            Program.userFriendAdd.Show(user);
                            break;
                        }
                    case "4":
                        {
                            Program.messageSendingView.Show(user);
                            break;
                        }
                    case "5":
                        {
                            Program.userIncomingMessageView.Show(user.IncomingMessages);
                            break;
                        }
                    case "6":
                        {
                            Program.userOutcomingMessageView.Show(user.OutcomingMessages);
                            break;
                        }
                    case "7":
                        {
                            Program.userFriendsView.Show(user.Friends);
                            break;
                        }
                }
            }
        }
    }
}
