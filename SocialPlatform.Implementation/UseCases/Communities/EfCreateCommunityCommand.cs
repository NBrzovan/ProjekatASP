using AutoMapper;
using FluentValidation;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.UseCases.Communities;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Communities
{
    public class EfCreateCommunityCommand : EfUseCase, ICreateCommunityCommand
    {
        private readonly IMapper _mapper;
        private readonly CreateCommunityDTOValidator _validator;
        public EfCreateCommunityCommand(SocialPlatformContext context, IMapper mapper, CreateCommunityDTOValidator validator) : base(context)
        {
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 7;

        public string Name => GetType().Name;

        public void Execute(CreateCommunityDTO data)
        {
            _validator.ValidateAndThrow(data);

            var community = _mapper.Map<Community>(data);

            Context.Communities.Add(community);
            Context.SaveChanges();
        }
    }
}
