namespace TagTweetMappingAccess
{
    using System;
    using System.Linq;
    using DataModel;
    using HashTagTweetMapsDTO;

    public class TagTweetMappingDb
    {
        private GlitterDBEntities db;
        public TagTweetMappingDb()
        {
            db = new GlitterDBEntities();
        }

        public void DeleteTagTweetMapping(HashTagTweetMapDTO hashTagTweetMapDTO)
        {
            try {
                //get the hashTagMapping object from the database
                var hashTagTweetMapObj = db.HashTagTweetMaps
                    .Where(x => x.TweetId == hashTagTweetMapDTO.TweetId && x.HashTagId == hashTagTweetMapDTO.HashTagId).FirstOrDefault();
                if (hashTagTweetMapObj != null)
                {
                    db.HashTagTweetMaps.Remove(hashTagTweetMapObj);
                    Save();
                }
            }
            catch (Exception) {
                Console.WriteLine("Error in database connectivity");
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
