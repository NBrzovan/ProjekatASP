using FluentValidation;
using SocialPlatform.Application.DTO.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Validators.Answers
{
    public class UpdateAnswerDTOValidator : AbstractValidator<UpdateAnswerDTO>
    {
        public UpdateAnswerDTOValidator()
        {
            RuleFor(dto => dto.Id)
                .NotEmpty().WithMessage("Answer ID is required.");

            RuleFor(dto => dto.Body)
                .NotEmpty().WithMessage("Body is required.");
        }
    }
}
