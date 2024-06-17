using FluentValidation;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Validators.Questions
{
    public class UpdateQuestionDTOValidator : AbstractValidator<UpdateQuestionDTO>
    {
        private readonly SocialPlatformContext _context;

        public UpdateQuestionDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(dto => dto.Id)
                .NotEmpty().WithMessage("Question ID is required.");

            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Title is required.");

            RuleFor(dto => dto.Excerpt)
                .NotEmpty().WithMessage("Excerpt is required.");

            RuleFor(dto => dto.Body)
                .NotEmpty().WithMessage("Body is required.");

            RuleFor(dto => dto.TagIds)
                .NotEmpty().WithMessage("Tag IDs are required.");
                
        }
    }
}
