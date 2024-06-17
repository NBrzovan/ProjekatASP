using AutoMapper;
using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases;
using SocialPlatform.Application.UseCases.Logs;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Logs
{
    public class EfGetUseCaseLogsQuery : EfUseCase,IGetUseCaseLogsQuery
    {
        private readonly IMapper _mapper;
        public EfGetUseCaseLogsQuery(SocialPlatformContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 30;

        public string Name => GetType().Name;

        public PagedResponseDTO<GetUseCaseLogsDTO> Execute(UseCaseLogsPagedSearchDTO search)
        {
            IQueryable<UseCaseLog> query = Context.UseCaseLogs;

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.UseCaseName == search.Keyword || x.UseCaseName == search.Keyword); 
            }

            if (search.DateStart != null)
            {
                query = query.Where(x => x.ExecutedAt >= search.DateStart);
            }

            if (search.DateEnd != null)
            {
                query = query.Where(x => x.ExecutedAt <= search.DateEnd);
            }

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            var response = new PagedResponseDTO<GetUseCaseLogsDTO>();

            response.TotalCount = query.Count();

            response.Data = query.Skip(skip)
                                 .Take(perPage)
                                 .Select(query => _mapper.Map<GetUseCaseLogsDTO>(query))
                                 .ToList();

            response.CurrentPage = page;

            response.ItemsPerPage = perPage;

            return response;
        }
    }
}

