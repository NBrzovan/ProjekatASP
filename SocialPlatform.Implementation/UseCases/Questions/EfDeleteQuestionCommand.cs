using SocialPlatform.Application;
using SocialPlatform.Application.UseCases.Questions;
using SocialPlatform.DataAccess;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Questions
{
    public class EfDeleteQuestionCommand : EfUseCase, IDeleteQuestionCommand
    {
        private readonly IApplicationActor _actor;
        public EfDeleteQuestionCommand(SocialPlatformContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 17;
        public string Name => GetType().Name;

        public void Execute(int data)
        {
            var question = Context.Questions.Find(data);

            if (question == null || question.UserId != _actor.Id)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            Context.Questions.Remove(question);
            Context.SaveChanges();
        }
    }
}

