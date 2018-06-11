namespace GlitterApplication.Controllers
{
    using System;
    using System.Web.Http;
    using UserBusinessLogic;
    using UsersDTO;

    //[Authorize]
    [AllowCrossSiteJson]
    public class UsersController : ApiController
    {
        UserBL userBL = new UserBL();                
        [HttpPost]
        // custom register - save the basic informations of user
        public Boolean Register(UserDTO user)
        {
            return userBL.RegisterUser(user);
        }

        // get the tweets of the logged in user
        [Route("api/users/{email}/tweets")]
        public IHttpActionResult GetUserTweets(string email)
        {
            if (email != "")
            {
                return Ok(userBL.GetAllTweets(email));
            }
            else
            {
                return NotFound();
            }
        }

        // get the followers count of the logged in user
        [Route("api/users/{email}/getfollowerscount")]
        public IHttpActionResult GetUserFollowersCount(string email)
        {
            int? result = userBL.GetFollowersCount(email);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        // get the following count of the the logged in user
        [Route("api/users/{email}/getfollowingscount")]
        public IHttpActionResult GetUserFollowingsCount(string email)
        {
            int? result = userBL.GetFollowingsCount(email);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //used to search peoples
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers([FromUri]string search)
        {
            var result = userBL.GetSearchedUsers(search);
            if (result != null)
            {
                return Ok(result);
            }
            else {
                return NotFound();
            }
        }

        //used to get logged in user followings
        [HttpGet]
        [Route("api/users/{email}/followings")]
        public IHttpActionResult GetUserFollowings([FromUri]string email)
        {
            var result = userBL.GetUserFollowings(email);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        //used to get logged in user followers
        [HttpGet]
        [Route("api/users/{email}/followers")]
        public IHttpActionResult GetUserFollowers([FromUri]string email)
        {
            var result = userBL.GetUserFollowers(email);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("api/users/getmaxtweetuser")]
        public IHttpActionResult GetMAxTweetUser()
        {
            var result = userBL.GetMAxTweetUser();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}