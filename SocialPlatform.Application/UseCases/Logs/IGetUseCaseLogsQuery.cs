using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.UseCases.Logs
{
    public interface IGetUseCaseLogsQuery : IQuery<PagedResponseDTO<GetUseCaseLogsDTO>, UseCaseLogsPagedSearchDTO>
    {
    }
}
