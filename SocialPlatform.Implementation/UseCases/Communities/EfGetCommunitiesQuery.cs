using AutoMapper;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases;
using SocialPlatform.Application.UseCases.Communities;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Communities
{
    public class EfGetCommunitiesQuery : EfUseCase, IGetCommunitiesQuery
    {
        private readonly IMapper _mapper;
        public EfGetCommunitiesQuery(SocialPlatformContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => GetType().Name;

        public PagedResponseDTO<GetCommunitiesDTO> Execute(PagedSearchDTO search)
        {
            IQueryable<Community> query = Context.Communities.AsQueryable();

            var response = new PagedResponseDTO<GetCommunitiesDTO>();

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            response.TotalCount = query.Count();
            response.Data = query.Skip(skip)
                                 .Take(perPage)
                                 .Select(query => _mapper.Map<GetCommunitiesDTO>(query));

            response.CurrentPage = page;

            response.ItemsPerPage = perPage;

            return response;
        }
    }
}
