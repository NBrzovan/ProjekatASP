using AutoMapper;
using FluentValidation;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.UseCases.Users;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Validators.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Users
{
    public class EfCreateUserCommand : EfUseCase, ICreateUserCommand
    {

        private readonly CreateUserDTOValidator _createUserDTOValidator;
        private readonly IMapper _mapper;

        public EfCreateUserCommand(SocialPlatformContext context, CreateUserDTOValidator createUserDTOValidator, IMapper mapper)
            : base(context)
        {
            _createUserDTOValidator = createUserDTOValidator;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => GetType().Name;

        public void Execute(CreateUserDTO data)
        {
            _createUserDTOValidator.ValidateAndThrow(data);

            var user = _mapper.Map<User>(data);
            user.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);

            Context.Users.Add(user);
            Context.SaveChanges();
        }
    }
}
