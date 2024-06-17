using SocialPlatform.Application.UseCases.Followings;
using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Followings
{
    public class EfDeleteFollowCommunityCommand : EfUseCase, IDeleteFollowCommunityCommand
    {
        public EfDeleteFollowCommunityCommand(SocialPlatformContext context) : base(context)
        {
        }

        public int Id => 26;

        public string Name => GetType().Name;

        public void Execute(int data)
        {
            var unfollow = Context.UserCommunities.Find(data);

            if (unfollow == null)
            {
                // Handle case where question with given Id is not found
                return;
            }

            Context.UserCommunities.Remove(unfollow);
            Context.SaveChanges();
        }
    }
}

