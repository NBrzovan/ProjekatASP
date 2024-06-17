using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.DTO.Update
{
    public class UpdateUserAccessDTO
    {
        public int UserId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }

    }
}

