using AutoMapper;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases;
using SocialPlatform.Application.UseCases.Topics;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Topics
{
    public class EfGetTopicsQuery : EfUseCase, IGetTopicsQuery
    {
        private readonly IMapper _mapper;
        public EfGetTopicsQuery(SocialPlatformContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => GetType().Name;

        public PagedResponseDTO<GetTopicsDTO> Execute(PagedSearchDTO search)
        {
            IQueryable<Topic> query = Context.Topics.AsQueryable();

            var response = new PagedResponseDTO<GetTopicsDTO>();

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            response.TotalCount = query.Count();
            response.Data = query.Skip(skip)
                                 .Take(perPage)
                                 .Select(query => _mapper.Map<GetTopicsDTO>(query));

            response.CurrentPage = page;

            response.ItemsPerPage = perPage;

            return response;
        }
    }
}

