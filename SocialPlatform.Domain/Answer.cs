using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Domain
{
    public class Answer : Entity
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int? ParentId { get; set; }
        public string Body { get; set; }
        public Question Question { get; set; }
        public User User { get; set; }
        public Answer ParentAnswer { get; set; }
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();  
    }
}
