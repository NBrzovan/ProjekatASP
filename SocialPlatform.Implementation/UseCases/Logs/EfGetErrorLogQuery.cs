using AutoMapper;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases.Logs;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SocialPlatform.Implementation.UseCases.Logs
{
    public class EfGetErrorLogQuery : EfUseCase, IGetErrorLogQuery
    {
        private readonly IMapper _mapper;
        public EfGetErrorLogQuery(SocialPlatformContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 31;
        public string Name => GetType().Name;
        public GetErrorsLogDTO Execute(Guid search)
        {
            var error = Context.ErrorLogs.Find(search);

            if (error == null)
                throw new EntityNotFoundException($"Record with ID {search} not found.");

            var response = _mapper.Map<GetErrorsLogDTO>(error);

            return response;
        }
    }
}

