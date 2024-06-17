using SocialPlatform.Application;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.UseCases.Reactions;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Reactions
{
    public class EfCreateLikeReactionCommand : EfUseCase, ICreateLikeReactionCommand
    {
        private readonly IApplicationActor _actor;
        private const bool LikeReaction = true;
        private readonly CreateReactionDTOValidator _validator;
        public EfCreateLikeReactionCommand(SocialPlatformContext context, IApplicationActor actor, CreateReactionDTOValidator validator)
            : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        public int Id => 28;

        public string Name => GetType().Name;

        public void Execute(CreateReactionDTO data)
        {
            _validator.Validate(data);

            var existingReaction = Context.Reactions
                .FirstOrDefault(r => r.QuestionId == data.QuestionId && r.UserId == _actor.Id);

            if (existingReaction != null)
            {
                existingReaction.ReactionType = LikeReaction;
                Context.SaveChanges();
            }
            else
            {
                var newReaction = new Reaction
                {
                    QuestionId = data.QuestionId,
                    UserId = _actor.Id,
                    ReactionType = LikeReaction
                };

                Context.Reactions.Add(newReaction);
                Context.SaveChanges();
            }
        }
    }
}

