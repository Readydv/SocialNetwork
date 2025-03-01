using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialNetwork.DAL.Repositories.FriendRepository;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService ()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public IEnumerable<User> GetFriendsByUserId(int userId)
        {
            return friendRepository.FindAllByUserId(userId)
                    .Select(friendsEntity =>
                    {
                        var userService = new UserService();
                        return userService.FindById(friendsEntity.friend_id);
                    });
        }

        public void AddFriend(FriendData friendData)
        {
            var findUserEntity = this.userRepository.FindByEmail(friendData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendData.UserId,
                friend_id = findUserEntity.id,
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
