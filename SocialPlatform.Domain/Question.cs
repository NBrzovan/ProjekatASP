using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Domain
{
    public class Question : Entity
    {
        public int CommunityId { get; set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Body { get; set; }
        public Topic Topic { get; set; }
        public User User { get; set; }
        public Community Community { get; set; }
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public ICollection<QuestionTag> Tags { get; set; } = new List<QuestionTag>();
        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
    }
}
