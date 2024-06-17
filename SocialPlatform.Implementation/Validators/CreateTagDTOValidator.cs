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
    public class CreateTagDTOValidator : AbstractValidator<CreateTagDTO>
    {
        private readonly SocialPlatformContext _context;
        public CreateTagDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name property cannot be empty.")
                .Must(BeUniqueName).WithMessage("Name already exists in the database.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Description property cannot be empty.");
        }

        private bool BeUniqueName(string name)
        {
            return !_context.Tags.Any(x => x.Name == name);
        }
    }
}

