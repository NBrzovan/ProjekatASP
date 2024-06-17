using SocialPlatform.Application.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO
{
    public class UserPagedSearchDTO : PagedSearchDTO
    {
        public string? Keyword { get; set; }
    }
}

