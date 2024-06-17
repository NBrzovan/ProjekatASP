using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Domain
{
    public class Reaction : Entity
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public bool ReactionType { get; set; } 
        public Question Question { get; set; }
        public User User { get; set; }
    }
}
