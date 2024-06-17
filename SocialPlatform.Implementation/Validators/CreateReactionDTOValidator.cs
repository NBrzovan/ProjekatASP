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
    public class CreateReactionDTOValidator : AbstractValidator<CreateReactionDTO>
    {
        private readonly SocialPlatformContext _context;

        public CreateReactionDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(dto => dto.QuestionId)
                .NotEmpty().WithMessage("QuestionId je obavezno polje.")
                .Must(QuestionExists).WithMessage("Pitanje sa datim ID-om ne postoji.");
        }

        private bool QuestionExists(int questionId)
        {
            return _context.Questions.Any(q => q.Id == questionId);
        }
    }
}

