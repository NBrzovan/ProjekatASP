using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases.Questions;
using SocialPlatform.DataAccess;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Questions
{
    public class EfGetQuestionQuery : EfUseCase, IGetQuestionQuery
    {
        private readonly IMapper _mapper;
        public EfGetQuestionQuery(SocialPlatformContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 18;

        public string Name => GetType().Name;

        public GetQuestionDTO Execute(int search)
        {
            var question = Context.Questions
                        .Include(q => q.Topic)
                        .Include(q => q.User)
                        .Include(q => q.Community)
                        .Include(q => q.Answers)
                            .ThenInclude(a => a.User) 
                        .Include(q => q.Tags)
                            .ThenInclude(qt => qt.Tag)
                        .Include(q => q.Reactions)
                        .FirstOrDefault();

            if (question == null)
                throw new EntityNotFoundException($"Record with ID {search} not found.");

            var response = _mapper.Map<GetQuestionDTO>(question);

            return response;
            
        }
    }
}

