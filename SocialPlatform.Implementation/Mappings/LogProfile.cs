using AutoMapper;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Mappings
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<Domain.UseCaseLog, GetUseCaseLogsDTO>();

            CreateMap<ErrorLog, GetErrorsLogDTO>();
        }

    }
}
