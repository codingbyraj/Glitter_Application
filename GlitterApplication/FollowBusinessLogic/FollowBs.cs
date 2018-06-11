using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FollowAccess;
using FollowsDTO;

namespace FollowBusinessLogic
{
    public class FollowBs
    {
        private FollowDb objDb;
        public FollowBs()
        {
            objDb = new FollowDb();
        }


        public void AddFollowing(FollowDTO follower)
        {
            if (objDb.AddFollowing(follower))
            {
                IncreaseFollowing(follower.FollowerId, follower.FollowingId);
            }
        }


        public void DeleteFollowing(FollowDTO follower)
        {
            if (objDb.DeleteFollowing(follower))
            {
                DecreaseFollower(follower.FollowerId, follower.FollowingId);
            }
        }

        public void IncreaseFollowing(int userId, int followingId)
        {
            objDb.IncreaseFollowing(userId, followingId);
        }

        public void DecreaseFollower(int userId, int followingId)
        {
            objDb.DecreaseFollowing(userId, followingId);
        }

    }
}
