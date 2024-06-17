using SocialPlatform.Application.UseCases.Users;
using SocialPlatform.DataAccess;
using SocialPlatform.Implementation.Exceptions;
using SocialPlatform.Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Users
{
    public class EfDeleteUserCommand : EfUseCase, IDeleteUserCommand
    {
        public EfDeleteUserCommand(SocialPlatformContext context) : base(context)
        {
        }

        public int Id => 12;
        public string Name => GetType().Name;
        public void Execute(int data)
        {
            var user = Context.Users.Find(data);

            if (user is null)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            Context.Remove(user);
            Context.SaveChanges();
        }
    }
}
