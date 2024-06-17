using SocialPlatform.Application.UseCases.Tags;
using SocialPlatform.DataAccess;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Tags
{
    public class EfDeleteTagCommand : EfUseCase, IDeleteTagCommand
    {
        public EfDeleteTagCommand(SocialPlatformContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => GetType().Name;

        public void Execute(int data)
        {
            var tag = Context.Tags.Find(data);

            if (tag == null)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            Context.Tags.Remove(tag);
            Context.SaveChanges();
        }
    }
}

