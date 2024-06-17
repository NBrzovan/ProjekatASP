using AutoMapper;
using FluentValidation;
using SocialPlatform.Application;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.UseCases.Answers;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Validators.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Answers
{
    public class EfCreateAnswerCommand : EfUseCase, ICreateAnswerCommand
    {
        private readonly IMapper _mapper;
        private readonly CreateAnswerDTOValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateAnswerCommand(SocialPlatformContext context,
                                     IMapper mapper,
                                     CreateAnswerDTOValidator validator,
                                     IApplicationActor actor) : base(context)
        {
            _mapper = mapper;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 20;

        public string Name => GetType().Name;

        public void Execute(CreateAnswerDTO data)
        {
            _validator.ValidateAndThrow(data);

            var answer = new Answer
            {
                QuestionId = data.QuestionId,
                Body = data.Body,
                UserId = _actor.Id,
            };

            if (data.ParentId.HasValue)
            {
                answer.ParentId = data.ParentId.Value;
            }

            Context.Answers.Add(answer);
            Context.SaveChanges();
        }
    }
}

