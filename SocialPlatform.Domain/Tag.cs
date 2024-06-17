using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Domain
{
    public class Tag : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<QuestionTag> Questions { get; set; } = new List<QuestionTag>();
    }
}
