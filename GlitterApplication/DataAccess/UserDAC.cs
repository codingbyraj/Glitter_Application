namespace DataAccess
{
    using DataModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using TweetsDTO;
    using UsersDTO;

    public class UserDAC
    {
        public UserDTO GetUser()
        {
            UserDTO returnedObject = null;
            try
            {
                using (GlitterDBEntities context = new GlitterDBEntities())
                {
                    var user = (from u in context.Users
                                select u).First();

                    UserDTO userDTO = new UserDTO
                    {
                        Name = user.Name,
                        ContactNumber = user.ContactNumber,
                        ProfileImage = user.ProfileImage,
                        Email = user.Email,
                        Country = user.Country,
                        FollowerCount = user.FollowerCount,
                        FollowingCount = user.FollowingCount
                    };
                    returnedObject = userDTO;
                }
            }
            catch (Exception)
            {
                returnedObject = null;
            }
            return returnedObject;
        }

        public Boolean RegisterUserToDatabase(UserDTO user)
        {
            Boolean result;
            try
            {
                using (GlitterDBEntities context = new GlitterDBEntities())
                {
                    User userDTO = new User
                    {
                        Name = user.Name,
                        ContactNumber = user.ContactNumber,
                        ProfileImage = user.ProfileImage,
                        Email = user.Email,
                        Country = user.Country,
                        FollowerCount = 0,
                        FollowingCount = 0
                    };
                    context.Users.Add(userDTO);
                    if (context.SaveChanges() > 0)
                    {
                        result = false;
                    }
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        // get all tweets        
        public IList<TweetDTO> GetUserTweets(string email)
        {
            IList<TweetDTO> returnedObject = null;
            try
            {
                using (GlitterDBEntities context = new GlitterDBEntities())
                {
                    int id = context.Users.Where(x => x.Email == email).FirstOrDefault().UserId;
                    IList<TweetDTO> tweets = new List<TweetDTO>();
                    var followersIds = context.Follows.Where(x => x.FollowerId == id)
                            .Select(x => x.FollowingId).ToList();
                    followersIds.Add(id);
                    foreach (var i in followersIds)
                    {
                        var result = context.Tweets.Where(x => x.UserId == i).ToList();
                        foreach (var item in result)
                        {
                            var likeFlag = context.Reactions
                                .Where(x => x.TweetId == item.TweetId && x.UserId == id)
                                .Select(x => x.LikeFlag).FirstOrDefault();
                            TweetDTO tweet = new TweetDTO();
                            tweet.TweetId = item.TweetId;
                            tweet.TweetContent = item.TweetContent;
                            tweet.UserId = item.UserId;
                            tweet.Time = item.Time;
                            if (i == id)
                            {
                                tweet.Email = email;
                            }
                            else
                            {
                                tweet.Email = "dummy@gmail.com";
                            }
                            tweet.LikeFlag = likeFlag;
                            tweets.Add(tweet);
                        }
                    }
                    IList<TweetDTO> sortedTweets = tweets.OrderByDescending(o => o.Time).ToList();
                    returnedObject = sortedTweets;
                }
            }
            catch (Exception)
            {

            }
            return returnedObject;
        }

        // get user's follwers count
        public int? GetUserFollowersCount(string email)
        {
            int? returnedObject = null;
            try
            {
                using (GlitterDBEntities context = new GlitterDBEntities())
                {
                    int? result = context.Users.Where(x => x.Email == email).FirstOrDefault().FollowerCount;
                    returnedObject = result;
                }
            }
            catch (Exception)
            {
                returnedObject = null;
            }
            return returnedObject;
        }

        // get user's follwings count
        public int? GetUserFollowingsCount(string email)
        {
            int? returnedObject = null;
            try
            {
                using (GlitterDBEntities context = new GlitterDBEntities())
                {
                    int? result = context.Users.Where(x => x.Email == email).FirstOrDefault().FollowingCount;
                    returnedObject = result;
                }
            }
            catch (Exception)
            {
                returnedObject = null;
            }
            return returnedObject;
        }

        // used to search people based on the search string passed
        public IList<UserDTO> GetUsers(string search)
        {
            IList<UserDTO> returnedObject;
            try
            {
                using (GlitterDBEntities context = new GlitterDBEntities())
                {
                    var users = context.Users.Where(x => x.Name.Contains(search) ||
                                x.Email.Contains(search)).ToList();
                    IList<UserDTO> usersDTO = new List<UserDTO>();

                    foreach (var user in users)
                    {
                        UserDTO userDTO = new UserDTO();
                        userDTO.Name = user.Name;
                        userDTO.ContactNumber = user.ContactNumber;
                        userDTO.Country = user.Country;
                        userDTO.Email = user.Email;
                        userDTO.ProfileImage = user.ProfileImage;
                        userDTO.FollowerCount = user.FollowerCount;
                        userDTO.FollowingCount = user.FollowingCount;
                        userDTO.UserId = user.UserId;
                        usersDTO.Add(userDTO);
                    }
                    returnedObject = usersDTO;
                }
            }
            catch (Exception)
            {
                returnedObject = null;
            }
            return returnedObject;
        }

        //used to retrieve user followings
        public IList<UserDTO> GetUserFollowings(string email)
        {
            IList<UserDTO> returnedObject;
            try
            {
                using (GlitterDBEntities context = new GlitterDBEntities())
                {
                    int userId = context.Users.Where(x => x.Email == email)
                        .Select(x => x.UserId).FirstOrDefault();
                    var users = context.Follows.Where(x => x.FollowerId == userId)
                                  .Include(x => x.User1).Select(y => y.User1).ToList();
                    IList<UserDTO> usersDTO = new List<UserDTO>();
                    foreach (var user in users)
                    {
                        UserDTO userDTO = new UserDTO();
                        userDTO.UserId = user.UserId;
                        userDTO.Name = user.Name;
                        userDTO.ContactNumber = user.ContactNumber;
                        userDTO.Country = user.Country;
                        userDTO.Email = user.Email;
                        userDTO.ProfileImage = user.ProfileImage;
                        userDTO.FollowerCount = user.FollowerCount;
                        userDTO.FollowingCount = user.FollowingCount;
                        usersDTO.Add(userDTO);
                    }
                    returnedObject = usersDTO;
                }
            }
            catch (Exception)
            {
                returnedObject = null;
            }
            return returnedObject;
        }

        // used to retrieve the follwers of the logged in user
        public IList<UserDTO> GetUserFollowers(string email)
        {
            IList<UserDTO> returnedObject;
            try
            {
                using (GlitterDBEntities context = new GlitterDBEntities())
                {
                    int userId = context.Users.Where(x => x.Email == email)
                        .Select(x => x.UserId).FirstOrDefault();
                    var users = context.Follows.Where(x => x.FollowingId == userId)
                                       .Include(x => x.User).Select(y => y.User).ToList();
                    IList<UserDTO> usersDTO = new List<UserDTO>();
                    foreach (var user in users)
                    {
                        UserDTO userDTO = new UserDTO();
                        userDTO.UserId = user.UserId;
                        userDTO.Name = user.Name;
                        userDTO.ContactNumber = user.ContactNumber;
                        userDTO.Country = user.Country;
                        userDTO.Email = user.Email;
                        userDTO.ProfileImage = user.ProfileImage;
                        userDTO.FollowerCount = user.FollowerCount;
                        userDTO.FollowingCount = user.FollowingCount;
                        usersDTO.Add(userDTO);
                    }
                    returnedObject = usersDTO;
                }
            }
            catch (Exception)
            {
                returnedObject = null;
            }
            return returnedObject;
        }

        public string GetMAxTweetUser()
        {
            string returnedUser =null;
            try {
                using (GlitterDBEntities context = new GlitterDBEntities())
                {
                    var result = context.Tweets.GroupBy(c => c.UserId)
                                    .Select(g => new
                                    {
                                        userid = g.Max(x => x.UserId)
                                    })
                                    .OrderBy(c => c.userid).FirstOrDefault();
                    // the userid of the most tweet user
                    int userid = result.userid;
                    string user = context.Users
                        .Where(x => x.UserId == result.userid).Select(x => x.Name).FirstOrDefault();
                    returnedUser =  user;
                }
            }
            catch (Exception) {
                
            }
            return returnedUser;
        }
    }
}