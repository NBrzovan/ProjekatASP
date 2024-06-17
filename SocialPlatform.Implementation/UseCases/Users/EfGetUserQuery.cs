using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases.Users;
using SocialPlatform.DataAccess;
using SocialPlatform.Implementation.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Users
{
    public class EfGetUserQuery : EfUseCase, IGetUserQuery
    {
        private readonly IMapper _mapper;
        public EfGetUserQuery(SocialPlatformContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 13;

        public string Name => GetType().Name;

        public GetUserDTO Execute(int search)
        {
            var user = Context.Users.Include(u => u.Questions)
                                    .Include(u => u.Answers)
                                    .Include(u => u.Followers)
                                    .Include(u => u.Followings)
                                        .ThenInclude(u => u.User)
                                    .Include(u => u.Reactions)
                                    .Include(u => u.Communities)
                                    .ThenInclude(u => u.Community)
                                    .FirstOrDefault(u => u.Id == search);

            if (user is null)
                throw new EntityNotFoundException($"Record with ID {search} not found.");

            var response = _mapper.Map<GetUserDTO>(user);

            return response;
        }
    }
}

