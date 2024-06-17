using FluentValidation;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Validators
{
    public class UpdateUserAccessDtoValidator : AbstractValidator<UpdateUserAccessDTO>
    {
        private static int updateUserAccessId = 34;
        public UpdateUserAccessDtoValidator(SocialPlatformContext context)
        {

            RuleFor(x => x.UserId)
                    .Must(x => context.Users.Any(u => u.Id == x))
                    .WithMessage("Requested user doesn't exist.")
                    .Must(x => !context.UserUseCases.Any(u => u.UseCaseId == updateUserAccessId && u.UserId == x))
                    .WithMessage("Not allowed to change this user.");

            RuleFor(x => x.UseCaseIds)
                .NotEmpty().WithMessage("Parameter is required.")
                .Must(x => x.All(id => id > 0 && id <= 34)).WithMessage("Invalid usecase id range.")
                .Must(x => x.Distinct().Count() == x.Count()).WithMessage("Only unique usecase ids must be delivered.");

        }
    }
}
