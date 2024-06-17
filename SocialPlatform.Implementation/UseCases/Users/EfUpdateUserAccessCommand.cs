using FluentValidation;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.Application.UseCases.Users;
using SocialPlatform.DataAccess;
using SocialPlatform.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Users
{
    public class EfUpdateUserAccessCommand : EfUseCase, IUpdateUserAccessCommand
    {
        private UpdateUserAccessDtoValidator _validator;
        public EfUpdateUserAccessCommand(SocialPlatformContext context,
             UpdateUserAccessDtoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 34;

        public string Name => GetType().Name;

        public void Execute(UpdateUserAccessDTO data)
        {
            _validator.ValidateAndThrow(data);

            var userUseCases = Context.UserUseCases
                                      .Where(x => x.UserId == data.UserId)
                                      .ToList();

            Context.UserUseCases.RemoveRange(userUseCases);

            Context.UserUseCases.AddRange(data.UseCaseIds.Select(x =>
            new Domain.UserUseCase
            {
                UserId = data.UserId,
                UseCaseId = x
            }));

            Context.SaveChanges();
        }
    }
}

