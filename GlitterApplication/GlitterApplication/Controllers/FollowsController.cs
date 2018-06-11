namespace GlitterApplication.Controllers
{
    using System.Web.Http;
    using FollowBusinessLogic;
    using FollowsDTO;

    [AllowCrossSiteJson]
    public class FollowsController : ApiController
    {
        private FollowBs followBs;
        public FollowsController()
        {
            followBs = new FollowBs();
        }

        [HttpPost]
        [Route("api/follows/follow")]
        public IHttpActionResult Follow(FollowDTO followDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            followBs.AddFollowing(followDTO);
            return Ok(followDTO);
        }

        [HttpPost]
        [Route("api/follows/unfollow")]
        public IHttpActionResult Unfollow(FollowDTO followDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            followBs.DeleteFollowing(followDTO);
            return Ok(followDTO);
        }
    }
}
