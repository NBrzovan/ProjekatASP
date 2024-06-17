using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Domain
{
    public class Follow : Entity
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int UserId { get; set; }
        public User Follower { get; set; }
        public User User { get; set; }
    }
}
