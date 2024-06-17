using FluentValidation;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Validators.Answers
{
    public class CreateAnswerDTOValidator : AbstractValidator<CreateAnswerDTO>
    {
        private readonly SocialPlatformContext _context;

        public CreateAnswerDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(dto => dto.QuestionId)
                .NotEmpty().WithMessage("Question ID is required.")
                .Must(BeExistingQuestion).WithMessage("Question ID does not exist in the database.");

            RuleFor(dto => dto.Body)
                .NotEmpty().WithMessage("Body is required.");

            RuleFor(dto => dto.ParentId)
                .Must(BeExistingAnswer).When(dto => dto.ParentId.HasValue)
                .WithMessage("Parent ID does not exist in the database.");
        }

        private bool BeExistingQuestion(int questionId)
        {
            return _context.Questions.Any(q => q.Id == questionId);
        }

        private bool BeExistingAnswer(int? parentId)
        {
            if (!parentId.HasValue)
                return true;

            return _context.Answers.Any(a => a.Id == parentId.Value);
        }
    }
}
