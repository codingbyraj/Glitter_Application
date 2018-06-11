using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactionAccess;
using ReactionsDTO;
namespace ReactionBusinessLogic
{
    public class ReactionBs
    {
        private ReactionDb objDb;
        public ReactionBs()
        {
            objDb = new ReactionDb();
        }

        public void AddTweetReaction(ReactionDTO reactionDTO)
        {
            objDb.AddTweetReaction(reactionDTO);
        }
    }
}
