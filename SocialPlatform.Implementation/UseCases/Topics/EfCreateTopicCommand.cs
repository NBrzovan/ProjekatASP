using AutoMapper;
using FluentValidation;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.UseCases.Topics;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using SocialPlatform.Implementation.Validators.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Topics
{
    public class EfCreateTopicCommand : EfUseCase, ICreateTopicCommand
    {
        private readonly CreateTopicDTOValidator _validator;
        private readonly IMapper _mapper;
        public EfCreateTopicCommand(SocialPlatformContext context, CreateTopicDTOValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => GetType().Name;

        public void Execute(CreateTopicDTO data)
        {
            _validator.ValidateAndThrow(data);

            var topic = _mapper.Map<Topic>(data);

            Context.Topics.Add(topic);
            Context.SaveChanges();
        }
    }
}

