using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tweet
{
    public class TweetDTO
    {
        public int TweetId { get;set;}
        public string TweetContent { get; set; }
        public int UserId { get; set; }
        public string Time{ get;set;}
}
}
