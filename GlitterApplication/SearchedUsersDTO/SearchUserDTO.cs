using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SearchedUsersDTO
{
    public class SearchUserDTO
    {
        
        public int UserId { get; set; }
        public string ContactNumber { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public string Name { get; set; }
        public bool IsFollowing { get; set; }

        public Nullable<int> FollowingCount { get; set; }
        public Nullable<int> FollowerCount { get; set; }
    }
}
