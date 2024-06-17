using FluentValidation;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Validators.Questions
{
    public class CreateQuestionDTOValidator : AbstractValidator<CreateQuestionDTO>
    {
        private readonly SocialPlatformContext _context;

        public CreateQuestionDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(dto => dto.CommunityId)
                .NotEmpty().WithMessage("Community ID is required.")
                .Must(CommunityExists).WithMessage("Community does not exist.");

            RuleFor(dto => dto.TopicId)
                .NotEmpty().WithMessage("Topic ID is required.")
                .Must(TopicExists).WithMessage("Topic does not exist.");

            RuleFor(dto => dto.Title)
                .NotEmpty().WithMessage("Title is required.");

            RuleFor(dto => dto.Excerpt)
                .NotEmpty().WithMessage("Excerpt is required.");

            RuleFor(dto => dto.Body)
                .NotEmpty().WithMessage("Body is required.");

            RuleFor(dto => dto.TagIds)
                .NotEmpty().WithMessage("Tag IDs are required.");
        }

        private bool CommunityExists(int communityId)
        {
            return _context.Communities.Any(c => c.Id == communityId);
        }

        private bool TopicExists(int topicId)
        {
            return _context.Topics.Any(t => t.Id == topicId);
        }

    }
}
