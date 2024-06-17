using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Domain
{
    public class UserCommunity 
    {
        public int UserId { get; set; }    
        public int CommunityId { get; set; }
        public User User { get; set; }
        public Community  Community { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
