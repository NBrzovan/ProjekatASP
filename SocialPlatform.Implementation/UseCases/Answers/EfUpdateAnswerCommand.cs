using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SocialPlatform.Application;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.Application.UseCases.Answers;
using SocialPlatform.Application.UseCases.Questions;
using SocialPlatform.DataAccess;
using SocialPlatform.Implementation.Exceptions;
using SocialPlatform.Implementation.Validators.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Answers
{
    public class EfUpdateAnswerCommand : EfUseCase, IUpdateAnswerCommand
    {
        private readonly UpdateAnswerDTOValidator _validator;
        private readonly IApplicationActor _actor;
        public EfUpdateAnswerCommand(SocialPlatformContext context,
                                     UpdateAnswerDTOValidator validator,
                                     IApplicationActor actor) : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 22;

        public string Name => GetType().Name;

        public void Execute(UpdateAnswerDTO data)
        {
            _validator.ValidateAndThrow(data);

            var answer = Context.Answers.Find(data.Id);

            if (answer == null || answer.UserId != _actor.Id)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            answer.Body = data.Body;

            Context.SaveChanges();
        }
    }
}

