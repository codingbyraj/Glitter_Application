namespace GlitterApplication.Controllers
{
    using System.Web.Http;
    using ReactionBusinessLogic;
    using ReactionsDTO;

    public class ReactionsController : ApiController
    {
        private ReactionBs reactionBs;
        public ReactionsController()
        {
            reactionBs = new ReactionBs();
        }



        [HttpPost]
        [System.Web.Http.Description.ResponseType(typeof(ReactionDTO))]
        [Route("api/reactions/")]
        public IHttpActionResult PostTweetReaction(ReactionDTO reactionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            reactionBs.AddTweetReaction(reactionDTO);
            return Ok(reactionDTO);
        }

    }
}
