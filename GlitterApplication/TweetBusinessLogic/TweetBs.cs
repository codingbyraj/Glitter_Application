using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetAccess;
using TweetsDTO;
using HashTagTweetMapsDTO;
using HashTagAccess;
using TagTweetMappingAccess;

namespace TweetBusinessLogic
{
    
    public class TweetBs
    {
        private TweetDb objDb;
        private HashTagDb objHashTagDb;
        private TagTweetMappingDb objTagTweetMappingDb;
        public TweetBs()
        {
            objDb = new TweetDb();
            objHashTagDb = new HashTagDb();
            objTagTweetMappingDb = new TagTweetMappingDb();
        }


        //Adding Tweet 
        public TweetDTO AddTweet(TweetDTO tweetDTO)

        {
            TweetDTO outTweetDTo = objDb.AddTweet(tweetDTO);
            IList<string> hashTags = GetHashTags(tweetDTO.TweetContent);


            foreach (string hashTag in hashTags)
            {
                int hashTagId = objDb.AddHashTag(hashTag);

                HashTagTweetMapDTO hashTagTweetMapDTO = new HashTagTweetMapDTO();

                hashTagTweetMapDTO.TweetId = outTweetDTo.TweetId;
                hashTagTweetMapDTO.HashTagId = hashTagId;

                AddTagTweetMapping(hashTagTweetMapDTO);
            }

            return outTweetDTo;
        }



       // used to delete a particular tweet from the databse
        public TweetDTO DeleteTweet(TweetDTO tweetDTO)
        {
            TweetDTO tweet = objDb.GetByID(tweetDTO.TweetId);
            //get all the hashtags contain in that tweet
            IList<string> hashTags = GetHashTags(tweet.TweetContent);
            //for each hashtag update the mapping Table  first and then update the hashtag table
            foreach (string hashTag in hashTags)
            {
                int hashTagId = objHashTagDb.GetHashTagId(hashTag);
                // update the hasshTagTweetMapping Table based on the hashtagId and the tweetId
                HashTagTweetMapDTO hashTagTweetMapDTO = new HashTagTweetMapDTO();
                hashTagTweetMapDTO.TweetId = tweetDTO.TweetId;
                hashTagTweetMapDTO.HashTagId = hashTagId;
                objTagTweetMappingDb.DeleteTagTweetMapping(hashTagTweetMapDTO);
                objHashTagDb.UpdateHashTag(hashTag);
            }
            objDb.Delete(tweet.TweetId);
            return tweet;
        }

        public IList<string> GetHashTags(string tweetContent)
        {
            string[] words = tweetContent.Split(' ');
            IList<string> hashTags = new List<string>();
            foreach (string word in words)
            {
                if (word.Length > 0)
                {
                    if (word[0] == '#')
                    {
                        hashTags.Add(word.Substring(1));
                    }
                }

            }
            return hashTags;
        }

        public void AddTagTweetMapping(HashTagTweetMapDTO hashTagTweetMapDTO)
        {
            objDb.AddTagTweetMapping(hashTagTweetMapDTO);
        }


        public IList<TweetDTO> GetSearchedTweets(string search)
        {
            return objDb.GetSearchedTweets(search);
        }


        public string GetTrendingHashTag()
        {
            return objDb.GetTrendingHashTag();

        }
    }
}
