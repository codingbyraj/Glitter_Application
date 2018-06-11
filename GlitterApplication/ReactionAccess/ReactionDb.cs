namespace ReactionAccess
{
    using System;
    using System.Linq;
    using DataModel;
    using ReactionsDTO;

    public class ReactionDb
    {
        private GlitterDBEntities db;
        public ReactionDb()
        {
            db = new GlitterDBEntities();
        }

        public void AddTweetReaction(ReactionDTO reactionDTO)
        {
            try {
                int userId = db.Users.Where(x => x.Email == reactionDTO.Email)
                .Select(x => x.UserId).FirstOrDefault();
                reactionDTO.UserId = userId;
                var reaction = db.Reactions
                    .Where(x => x.UserId == userId && x.TweetId == reactionDTO.TweetId).FirstOrDefault();
                if (reaction == null)
                {
                    Reaction reactionObj = new Reaction();
                    reactionObj.UserId = userId;
                    reactionObj.TweetId = reactionDTO.TweetId;
                    reactionObj.LikeFlag = reactionDTO.LikeFlag;
                    db.Reactions.Add(reactionObj);
                    Save();
                }
                else
                {   // if user already liked or unliked then change likeflag status                 
                    reaction.LikeFlag = reactionDTO.LikeFlag;
                    Save();
                }
            }
            catch (Exception) {
                Console.WriteLine("Error in database connection.");
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
