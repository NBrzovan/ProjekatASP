using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SocialPlatform.Application;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.Application.UseCases.Questions;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Exceptions;
using SocialPlatform.Implementation.Validators.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Questions
{
    public class EfUpdateQuestionCommand : EfUseCase, IUpdateQuestionCommand
    {
        private readonly UpdateQuestionDTOValidator _validator;
        private readonly IMapper _mapper;
        private readonly IApplicationActor _actor;
        public EfUpdateQuestionCommand(SocialPlatformContext context,
                                       UpdateQuestionDTOValidator validator,
                                       IMapper mapper,
                                       IApplicationActor actor)
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 16;

        public string Name => GetType().Name;

        public void Execute(UpdateQuestionDTO data)
        {
            _validator.ValidateAndThrow(data);

            var question = Context.Questions.FirstOrDefault(q => q.Id == data.Id);

            if (question == null || question.UserId != _actor.Id)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            /*question.Title = data.Title;
            question.Body = data.Body;
            question.Tags.Clear();

            foreach (var tagId in data.TagIds)
            {
                question.Tags.Add(new QuestionTag { TagId = tagId });
            }*/

            _mapper.Map(data, question);

            Context.SaveChanges();
        }
    }
}
