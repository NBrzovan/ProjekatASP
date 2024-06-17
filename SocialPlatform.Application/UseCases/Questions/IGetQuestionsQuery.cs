using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Application.UseCases.Questions
{
    public interface IGetQuestionsQuery : IQuery<PagedResponseDTO<GetQuestionsDTO>, QuestionPagedSearchDTO>
    {

    }
}
