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
    public class CreateFollowCommunityDTOValidator : AbstractValidator<CreateFollowCommunityDTO>
    {
        private readonly SocialPlatformContext _context;

        public CreateFollowCommunityDTOValidator(SocialPlatformContext context)
        {
            _context = context;

            RuleFor(dto => dto.CommunityId)
                .NotEmpty().WithMessage("Community Id is required.")
                .Must(BeExistingCommunity).WithMessage("Community with the given Id does not exist.");
        }

        private bool BeExistingCommunity(int communityId)
        {
            return _context.Communities.Any(c => c.Id == communityId);
        }
    }
}
