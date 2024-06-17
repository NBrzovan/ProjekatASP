using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases;
using SocialPlatform.Application.UseCases.Users;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Users
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        private readonly IMapper _mapper;
        public EfGetUsersQuery(SocialPlatformContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => GetType().Name;

        public PagedResponseDTO<GetUsersDTO> Execute(UserPagedSearchDTO search)
        {
            IQueryable<User> query = Context.Users
                .Include(u => u.Questions)
                .Include(u => u.Answers)
                .Include(u => u.Followers)
                .Include(u => u.Followings)
                .Include(u => u.Reactions)
                .Include(u => u.Communities)
                .ThenInclude(u => u.Community);

            var response = new PagedResponseDTO<GetUsersDTO>();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(q =>
                    q.FirstName.Contains(search.Keyword) ||
                    q.LastName.Contains(search.Keyword) ||
                    q.Username.Contains(search.Keyword) ||
                    q.Email.Contains(search.Keyword));
            }


            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            response.TotalCount = query.Count();
            response.Data = query.Skip(skip)
                                 .Take(perPage)
                                 .Select(query => _mapper.Map<GetUsersDTO>(query));

            response.CurrentPage = page;

            response.ItemsPerPage = perPage;

            return response;
        }
    }

}

