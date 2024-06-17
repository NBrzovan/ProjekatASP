using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Validators.Users
{
    public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
    {
        private readonly SocialPlatformContext _context;
        public CreateUserDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(user => user.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .Matches("^[A-Z][a-z]{2,14}$").WithMessage("Invalid first name format.");

            RuleFor(user => user.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Matches("^[A-Z][a-z]{4,29}$").WithMessage("Invalid last name format.");

            RuleFor(user => user.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Matches("^([a-z])[a-z0-9]{4,29}$").WithMessage("Invalid username format.")
                .Must(BeUniqueUsername).WithMessage("Username must be unique.");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Invalid email address format.")
                .Must(BeUniqueEmail).WithMessage("Email address must be unique.");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches("^(?=.*\\d)(?=.*[a-z]).{8,}$").WithMessage("Invalid password format.");
        }

        private bool BeUniqueEmail(string email)
        {
            return !_context.Users.Any(x => x.Email == email);
        }

        private bool BeUniqueUsername(string username)
        {
            return !_context.Users.Any(x => x.Username == username);
        }
    }
}
