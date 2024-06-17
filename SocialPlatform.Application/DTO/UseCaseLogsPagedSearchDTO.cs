using SocialPlatform.Application.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO
{
    public class UseCaseLogsPagedSearchDTO : PagedSearchDTO
    {
        public string? Keyword { get; set; }
        public string? Identity { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}

