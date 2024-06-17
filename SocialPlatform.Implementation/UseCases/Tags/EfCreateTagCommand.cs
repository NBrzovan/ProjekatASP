using AutoMapper;
using FluentValidation;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.UseCases.Tags;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Tags
{
    public class EfCreateTagCommand : EfUseCase, ICreateTagCommand
    {
        private readonly CreateTagDTOValidator _validator;
        private readonly IMapper _mapper;
        public EfCreateTagCommand(SocialPlatformContext context, CreateTagDTOValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => GetType().Name;

        public void Execute(CreateTagDTO data)
        {
            _validator.ValidateAndThrow(data);

            var tag = _mapper.Map<Tag>(data);

            Context.Tags.Add(tag);
            Context.SaveChanges();
        }
    }
}

