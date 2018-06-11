namespace TweetsDTO
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TweetDTO
    {
            [Key]
            public int TweetId { get; set; }
            public string TweetContent { get; set; }
            public int UserId { get; set; }
            public DateTime Time { get; set; }
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public string Email { get; set; }
            public bool? LikeFlag { get; set; }

    }
}
