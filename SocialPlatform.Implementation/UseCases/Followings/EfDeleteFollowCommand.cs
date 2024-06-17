using SocialPlatform.Application;
using SocialPlatform.Application.UseCases.Followings;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Followings
{
    public class EfDeleteFollowCommand : EfUseCase, IDeleteFollowCommand
    {
        private readonly IApplicationActor _actor;
        public EfDeleteFollowCommand(SocialPlatformContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        public int Id => 24;

        public string Name => GetType().Name;
        public void Execute(int data)
        {
            var unfollow = Context.Follows.Find(data);

            if (unfollow == null || unfollow.FollowerId != _actor.Id)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            Context.Follows.Remove(unfollow);
            Context.SaveChanges();
        }
    }
}
