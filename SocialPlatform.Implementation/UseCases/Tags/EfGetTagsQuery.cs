using AutoMapper;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases;
using SocialPlatform.Application.UseCases.Tags;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Tags
{
    public class EfGetTagsQuery : EfUseCase, IGetTagsQuery
    {
        private readonly IMapper _mapper;
        public EfGetTagsQuery(SocialPlatformContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name => GetType().Name;

        public PagedResponseDTO<GetTagsDTO> Execute(PagedSearchDTO search)
        {
            IQueryable<Tag> query = Context.Tags.AsQueryable();

            var response = new PagedResponseDTO<GetTagsDTO>();

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);


            response.TotalCount = query.Count();
            response.Data = query.Skip(skip)
                                 .Take(perPage)
                                 .Select(query => _mapper.Map<GetTagsDTO>(query));

            response.CurrentPage = page;

            response.ItemsPerPage = perPage;

            return response;
        }
    }
}

