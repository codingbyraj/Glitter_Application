namespace GlitterApplication.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Description;
    using TweetsDTO;
    using TweetBusinessLogic;

    [AllowCrossSiteJson]
    public class TweetsController : ApiController
    {
        private TweetBs tweetBs;
        public TweetsController()
        {
            tweetBs = new TweetBs();
        }

        [HttpPost]
        [ResponseType(typeof(TweetDTO))]
        [Route("api/tweets/addtweet")]
        public IHttpActionResult AddTweet(TweetDTO tweetDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            tweetDTO = tweetBs.AddTweet(tweetDTO);            
            if (tweetDTO != null)
            {
                return Ok(tweetDTO);
            }
            else
            {
                return NotFound();
            }
        }

        //used to delete a tweet from the logged in user
        [HttpDelete]
        [ResponseType(typeof(TweetDTO))]
        [Route("api/tweets/deletetweet")]
        public IHttpActionResult DeleteTweet(TweetDTO tweetDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            tweetDTO = tweetBs.DeleteTweet(tweetDTO);
            if (tweetDTO != null)
            {
                return Ok(tweetDTO);
            }
            else
            {
                return NotFound();
            }
        }

        //used to search tweets on the basis of the hashtags
        [HttpGet]
        [System.Web.Http.Route("api/tweets/gettweets")]
        public IHttpActionResult GetTwets(string search)
        {
            var result = tweetBs.GetSearchedTweets(search);
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
        [System.Web.Http.Route("api/tweets/gettrendinghashtag")]
        public IHttpActionResult GetTrendingHashTag()
        {
            var result = tweetBs.GetTrendingHashTag();
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
