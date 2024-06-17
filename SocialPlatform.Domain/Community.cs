using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Domain
{
    public class Community : Entity
    {
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<UserCommunity> Users { get; set; } = new List<UserCommunity>();
    }
}
