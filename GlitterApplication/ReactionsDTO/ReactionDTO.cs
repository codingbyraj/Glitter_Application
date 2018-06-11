namespace ReactionsDTO
{
    using System;
    public class ReactionDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public int TweetId { get; set; }
        public Nullable<bool> LikeFlag { get; set; }
    }
}
