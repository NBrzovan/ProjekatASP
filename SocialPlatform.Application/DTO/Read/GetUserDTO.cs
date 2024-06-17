using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO.Read
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Avatar {  get; set; }
        public List<GetFollowUserInfo>? Followers { get; set; }
        public List<GetFollowUserInfo>? Followings { get; set; }
        public List<GetCommunitiesDTO> Communities { get; set; }
    }

    public class GetFollowUserInfo
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}

