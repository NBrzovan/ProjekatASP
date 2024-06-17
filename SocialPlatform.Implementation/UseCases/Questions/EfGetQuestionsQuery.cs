using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialPlatform.Application.DTO;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.UseCases;
using SocialPlatform.Application.UseCases.Questions;
using SocialPlatform.DataAccess;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.UseCases.Questions
{
    public class EfGetQuestionsQuery : EfUseCase, IGetQuestionsQuery
    {
        private readonly IMapper _mapper;
        public EfGetQuestionsQuery(SocialPlatformContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 19;

        public string Name => GetType().Name;

        public PagedResponseDTO<GetQuestionsDTO> Execute(QuestionPagedSearchDTO search)
        {
            IQueryable<Question> query = Context.Questions
                                        .Include(q => q.User)
                                        .Include(q => q.Community)
                                        .Include(q => q.Answers);

            var response = new PagedResponseDTO<GetQuestionsDTO>();

            if (search.UserId != null)
            {
                query = query.Where(q => q.UserId == search.UserId);
            }

            if (!string.IsNullOrEmpty(search.Keywords))
            {
                string keyword = search.Keywords.ToLower();
                query = query.Where(q =>
                    q.User.FirstName.ToLower().Contains(keyword) ||
                    q.User.LastName.ToLower().Contains(keyword) ||
                    q.User.Email.ToLower().Contains(keyword) ||
                    q.Title.ToLower().Contains(keyword) ||
                    q.Answers.Any(a => a.Body.ToLower().Contains(keyword))
                );
            }

            if (search.TagIds != null && search.TagIds.Any())
            {
                query = query.Where(q => q.Tags.Any(t => search.TagIds.Contains(t.TagId)));
            }

            if (search.TopicIds != null && search.TopicIds.Any())
            {
                query = query.Where(q => search.TopicIds.Contains(q.TopicId));
            }

            if (search.CommunityId != null)
            {
                query = query.Where(q => q.CommunityId == search.CommunityId);
            }

            if (search.DateFrom != null)
            {
                query = query.Where(q => q.CreatedAt >= search.DateFrom);
            }

            if (search.DateTo != null)
            {
                query = query.Where(q => q.CreatedAt <= search.DateTo);
            }

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;


            int skip = perPage * (page - 1);

            response.TotalCount = query.Count();

            response.Data = query.Skip(skip)
                .Take(perPage)
                .Select(question => _mapper.Map<GetQuestionsDTO>(question)).ToList();

            response.CurrentPage = page;
            response.ItemsPerPage = perPage;

            return response;
        }
    }

}
