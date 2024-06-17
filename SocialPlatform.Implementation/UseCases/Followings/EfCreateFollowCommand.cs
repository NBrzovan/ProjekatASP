using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
    public class EfCreateFollowCommand : EfUseCase, ICreateFollowCommand
    {
        private readonly CreateFollowDTOValidator _validator;
        private readonly IApplicationActor _actor;
        public EfCreateFollowCommand(SocialPlatformContext context, CreateFollowDTOValidator validator, IApplicationActor actor)
            : base(context)
        {
            _validator = validator;
            _actor = actor;
        }

        public int Id => 23;

        public string Name => GetType().Name;

        public void Execute(CreateFollowDTO data)
        {
            data.FollowerId = _actor.Id;

            _validator.ValidateAndThrow(data);

            var existingFollow = Context.Follows
                .FirstOrDefault(f => f.FollowerId == data.FollowerId && f.UserId == data.UserId);

            if (existingFollow == null)
            {
                var newFollow = new Follow
                {
                    FollowerId = data.FollowerId,
                    UserId = data.UserId
                };

                Context.Follows.Add(newFollow);
                Context.SaveChanges(); 
            }
        }
    }
}

