using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.UseCases.Communities
{
    public interface IGetCommunitiesQuery : IQuery<PagedResponseDTO<GetCommunitiesDTO>, PagedSearchDTO>
    {
    }
}

