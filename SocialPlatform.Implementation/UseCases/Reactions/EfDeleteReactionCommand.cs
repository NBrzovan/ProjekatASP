using SocialPlatform.Application;
using SocialPlatform.Application.UseCases.Reactions;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Reactions
{
    public class EfDeleteReactionCommand : EfUseCase, IDeleteReactionCommand
    {
        private readonly IApplicationActor _actor;
        public EfDeleteReactionCommand(SocialPlatformContext context, IApplicationActor actor) 
            : base(context)
        {
            _actor = actor;
        }

        public int Id => 32;

        public string Name => GetType().Name;
        public void Execute(int data)
        {
            var reaction = Context.Reactions.Find(data);

            if (reaction == null || reaction.UserId != _actor.Id)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            Context.Reactions.Remove(reaction);
            Context.SaveChanges();
        }
    }
}

