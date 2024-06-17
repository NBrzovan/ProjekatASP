using SocialPlatform.Application.UseCases.Communities;
using SocialPlatform.DataAccess;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Communities
{
    public class EfDeleteCommunityCommand : EfUseCase, IDeleteCommunityCommand
    {
        public EfDeleteCommunityCommand(SocialPlatformContext context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => GetType().Name;

        public void Execute(int data)
        {
            var community = Context.Communities.Find(data);

            if (community == null)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            Context.Communities.Remove(community);
            Context.SaveChanges();
        }
    }
}
