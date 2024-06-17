using AutoMapper;
using SocialPlatform.Application.DTO.Create;
using SocialPlatform.Application.DTO.Read;
using SocialPlatform.Application.DTO.Update;
using SocialPlatform.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform.Implementation.Mappings
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<CreateQuestionDTO, Question>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagIds.Select(tagId => new QuestionTag { TagId = tagId })));

            CreateMap<UpdateQuestionDTO, Question>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagIds.Select(tagId => new QuestionTag { TagId = tagId })));

            CreateMap<Question, GetQuestionDTO>()
                .ForMember(dest => dest.Author,
                    opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.Topic,
                    opt => opt.MapFrom(src => src.Topic.Name))
                .ForMember(dest => dest.Likes,
                    opt => opt.MapFrom(src => src.Reactions.Count(r => r.ReactionType == true)))
                .ForMember(dest => dest.Dislikes,
                    opt => opt.MapFrom(src => src.Reactions.Count(r => r.ReactionType == false)))
                .ForMember(dest => dest.Answers,
                    opt => opt.MapFrom(src => src.Answers.Where(answer => answer.ParentId == null).Select(answer => new AnswersForQuestionDTO
                    {
                        Id = answer.Id,
                        Author = $"{answer.User.FirstName} {answer.User.LastName}",
                        Answer = answer.Body,
                        Createt = answer.CreatedAt,
                        Replies = answer.Answers.Select(reply => new AnswersForQuestionDTO
                        {
                            Id = reply.Id,
                            Author = $"{reply.User.FirstName} {reply.User.LastName}",
                            Answer = reply.Body,
                            Createt = reply.CreatedAt
                        }).ToList()
                    }).ToList()))
                .ForMember(dest => dest.Tags,
                    opt => opt.MapFrom(src => src.Tags.Select(tag => new TagsForQuestionDTO
                    {
                        Id = tag.Tag.Id,
                        Name = tag.Tag.Name
                    }).ToList()));

            CreateMap<Question, GetQuestionsDTO>()
                .ForMember(dest => dest.Community,
                    opt => opt.MapFrom(src => src.Community.Name))
                .ForMember(dest => dest.Author,
                    opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.Likes,
                    opt => opt.MapFrom(src => src.Reactions.Count(r => r.ReactionType == true)))
                .ForMember(dest => dest.Dislikes,
                    opt => opt.MapFrom(src => src.Reactions.Count(r => r.ReactionType == false)))
                .ForMember(dest => dest.Answers,
                    opt => opt.MapFrom(src => src.Answers.Count));
        }
    }
}

