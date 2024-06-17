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
    public class CreateCommunityDTOValidator : AbstractValidator<CreateCommunityDTO>
    {
        private readonly SocialPlatformContext _context;
        public CreateCommunityDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Name property cannot be empty.")
                .Must(BeUniqueName).WithMessage("Name already exists in the database.");
        }

        private bool BeUniqueName(string name)
        {
            return !_context.Communities.Any(x => x.Name == name);
        }
    }
}
