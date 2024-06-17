using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Avatar { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public ICollection<Follow> Followers { get; set; } = new List<Follow>();
        public ICollection<Follow> Followings { get; set; } = new List<Follow>();
        public ICollection<Reaction> Reactions { get; set; } = new List<Reaction>();
        public ICollection<UserCommunity> Communities { get; set; } = new List<UserCommunity>();
        public ICollection<UserUseCase> UseCases { get; set; } = new List<UserUseCase>();
    }
}
