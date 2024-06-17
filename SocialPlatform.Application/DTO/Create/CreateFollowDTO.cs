using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO.Create
{
    public class CreateFollowDTO
    {
        public int FollowerId { get; set; }
        public int UserId { get; set; }
    }
}
