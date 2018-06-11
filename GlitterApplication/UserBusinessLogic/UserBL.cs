using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetsDTO;
using UsersDTO;
namespace UserBusinessLogic
{
    public class UserBL
    {
        UserDAC userDAC = new UserDAC();

        public Boolean RegisterUser(UserDTO newUserDetails) {            
            return userDAC.RegisterUserToDatabase(newUserDetails);
        }

        // get user's all tweets
        public IList<TweetDTO> GetAllTweets(string email)
        {
            return userDAC.GetUserTweets(email);
        }


        // get user's followers
        public int? GetFollowersCount(string email)
        {
            return userDAC.GetUserFollowersCount(email);
        }

        // get user's followers
        public int? GetFollowingsCount(string email)
        {
            return userDAC.GetUserFollowingsCount(email);
        }


        public IList<UserDTO> GetSearchedUsers(string search) {
            return userDAC.GetUsers(search);
        }


        //used to retrieve user followings
        public IList<UserDTO> GetUserFollowings(string email)
        {
            return userDAC.GetUserFollowings( email);
        }

        //used to retrieve user followers
        public IList<UserDTO> GetUserFollowers(string email)
        {
            return userDAC.GetUserFollowers(email);
        }

        public string GetMAxTweetUser()
        {
            return userDAC.GetMAxTweetUser();
        }
    }
}
