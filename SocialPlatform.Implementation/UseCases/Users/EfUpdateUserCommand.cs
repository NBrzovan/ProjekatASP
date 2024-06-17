using AutoMapper;
using FluentValidation;
using SocialPlatform.Application;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.Application.UseCases.Users;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Exceptions;
using SocialPlatform.Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Users
{
    public class EfUpdateUserCommand : EfUseCase, IUpdateUserCommand
    {
        public readonly UpdateUserDTOValidator _validator;
        public IMapper _mapper;
        public IApplicationActor _actor;
        public EfUpdateUserCommand(SocialPlatformContext context, 
                                   UpdateUserDTOValidator validator,
                                   IMapper mapper,
                                   IApplicationActor actor) 
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
            _actor = actor;
        }

        public int Id => 11;

        public string Name => GetType().Name;

        public void Execute(UpdateUserDTO data)
        {
            _validator.ValidateAndThrow(data);
            var user = Context.Users.Find(data.Id);

            if (user == null || user.Id != _actor.Id)
                throw new EntityNotFoundException($"Record with ID {data} not found.");

            user.Email = data.Email;
            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.Username = data.Username;

            Context.SaveChanges();
        }
    }
}
