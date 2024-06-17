using FluentValidation;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Validators.Users
{
    public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
    {
        private readonly SocialPlatformContext _context;
        public UpdateUserDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(user => user.Id)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Matches("^[A-Z][a-z]{2,14}$").WithMessage("Invalid first name format.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Matches("^[A-Z][a-z]{4,29}$").WithMessage("Invalid last name format.");

            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Matches("^([a-z])[a-z0-9]{4,29}$").WithMessage("Invalid username format.")
                .Must((dto, username) => BeUniqueUsername(username, dto.Id)).WithMessage("Username must be unique.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Invalid email address format.")
                .Must((dto, email) => BeUniqueEmail(email, dto.Id)).WithMessage("Email address must be unique.");
        }

        private bool BeUniqueEmail(string email, int userId)
        {
            return !_context.Users.Any(x => x.Email == email && x.Id != userId);
        }

        private bool BeUniqueUsername(string username, int userId)
        {
            return !_context.Users.Any(x => x.Username == username && x.Id != userId);
        }
    }
}
