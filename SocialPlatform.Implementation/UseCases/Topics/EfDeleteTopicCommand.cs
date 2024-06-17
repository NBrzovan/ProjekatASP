using SocialPlatform.Application.UseCases.Topics;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Topics
{
    public class EfDeleteTopicCommand : EfUseCase, IDeleteTopicCommand
    {
        public EfDeleteTopicCommand(SocialPlatformContext context) : base(context)
        {
        }

        public int Id => 2;
        public string Name => GetType().Name;

        public void Execute(int data)
        {
            var topic = Context.Topics.Find(data);

            if (topic == null)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            Context.Topics.Remove(topic);
            Context.SaveChanges();
        }
    }
}

