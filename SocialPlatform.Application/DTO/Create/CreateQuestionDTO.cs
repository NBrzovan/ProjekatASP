using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO.Create
{
    public class CreateQuestionDTO
    {
        public int CommunityId { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string Body { get; set; }
        public List<int> TagIds { get; set; }
    }
}
