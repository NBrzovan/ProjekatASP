using AutoMapper;
using FluentValidation;
using SocialPlatform.Application;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.UseCases.Questions;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Validators.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Questions
{
    public class EfCreateQuestionCommand : EfUseCase, ICreateQuestionCommand
    {
        private readonly CreateQuestionDTOValidator _validator;
        private readonly IMapper _mapper;
        private IApplicationActor _actor;
        public EfCreateQuestionCommand(SocialPlatformContext context,
                                       CreateQuestionDTOValidator validator,
                                       IMapper mapper,
                                       IApplicationActor actor)
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 15;

        public string Name => GetType().Name;

        public void Execute(CreateQuestionDTO data)
        {
            _validator.ValidateAndThrow(data);

            var question = _mapper.Map<Question>(data);
            question.UserId = _actor.Id;

            Context.Questions.Add(question);
            Context.SaveChanges();
        }
    }
}

