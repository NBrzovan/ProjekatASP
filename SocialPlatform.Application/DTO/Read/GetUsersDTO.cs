using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO.Read
{
    public class GetUsersDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public int Followers { get; set; }
        public int Followings { get; set; }
        public int Reactions { get; set; }
        public int Questions { get; set; }
        public int Answers { get; set; }
        public List<GetCommunitiesDTO> Communities { get; set; } 
    }
}

