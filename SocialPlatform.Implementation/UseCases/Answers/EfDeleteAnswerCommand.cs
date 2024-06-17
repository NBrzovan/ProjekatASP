using SocialPlatform.Application;
using SocialPlatform.Application.UseCases.Answers;
using SocialPlatform.DataAccess;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Answers
{
    public class EfDeleteAnswerCommand : EfUseCase, IDeleteAnswerCommand
    {
        private readonly IApplicationActor _actor;
        public EfDeleteAnswerCommand(SocialPlatformContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 21;

        public string Name => GetType().Name;
        public void Execute(int data)
        {
            var answer = Context.Answers.Find(data);

            if (answer == null || answer.UserId != _actor.Id)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            Context.Answers.Remove(answer);
            Context.SaveChanges();
        }
    }
}
