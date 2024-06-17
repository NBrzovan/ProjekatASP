using SocialPlatform.Application;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.UseCases.Followings;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Followings
{
    public class EfCreateFollowCommunityCommand : EfUseCase, ICreateFollowCommunityCommand
    {
        private readonly IApplicationActor _actor;
        private readonly CreateFollowCommunityDTOValidator _validator;
        public EfCreateFollowCommunityCommand(SocialPlatformContext context, IApplicationActor actor, CreateFollowCommunityDTOValidator validator)
            : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        public int Id => 25;

        public string Name => GetType().Name;

        public void Execute(CreateFollowCommunityDTO data)
        {

            _validator.Validate(data);

            var existingFollow = Context.UserCommunities.
                FirstOrDefault(cu => cu.UserId == _actor.Id && cu.CommunityId == data.CommunityId);

            if (existingFollow == null)
            {
                var newFollow = new UserCommunity
                {
                    UserId = _actor.Id,
                    CommunityId = data.CommunityId
                };

                Context.UserCommunities.Add(newFollow);
                Context.SaveChanges();
            }
        }
    }
}

