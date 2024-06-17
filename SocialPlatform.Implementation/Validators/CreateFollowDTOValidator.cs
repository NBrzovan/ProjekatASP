using FluentValidation;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Validators
{
    public class CreateFollowDTOValidator : AbstractValidator<CreateFollowDTO>
    {
        private readonly SocialPlatformContext _context;

        public CreateFollowDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(dto => dto.FollowerId)
                .NotEmpty().WithMessage("Follower ID is required.")
                .Must(BeExistingUser).WithMessage("Follower ID does not exist in the database.");

            RuleFor(dto => dto.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .Must(BeExistingUser).WithMessage("User ID does not exist in the database.");

            RuleFor(dto => new { dto.FollowerId, dto.UserId })
                .Must((dto, _) => dto.FollowerId != dto.UserId)
                .WithMessage("Follower ID and User ID cannot be the same.");
        }

        private bool BeExistingUser(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }
    }
}
