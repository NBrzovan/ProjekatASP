using SocialPlatform.Application.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO
{
    public class QuestionPagedSearchDTO : PagedSearchDTO
    {
        public int? UserId { get; set; }
        public string? Keywords { get; set; }
        public List<int>? TagIds { get; set; }
        public List<int>? TopicIds { get; set; }
        public int? CommunityId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

}
