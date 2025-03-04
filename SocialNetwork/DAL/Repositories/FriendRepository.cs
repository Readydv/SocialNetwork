﻿using SocialNetwork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialNetwork.DAL.Repositories.FriendRepository;

namespace SocialNetwork.DAL.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity> (@"select * from id where user_id = :user_id", new { userId = userId});
        }

        public int Create (FriendEntity friendEntity)
        {
            return Execute(@"insert into friends (user_id,friend_id) values (:user_id,:friend_id)", friendEntity);
        }

        public int Delete(int id)
        {
            return Execute(@"delete from friends where id = :id_p", new { id_p = id });
        }

        public interface IFriendRepository
        {
            IEnumerable<FriendEntity> FindAllByUserId(int userId);
            int Create(FriendEntity friendEntity);
            int Delete(int id);
        }
    }
}
