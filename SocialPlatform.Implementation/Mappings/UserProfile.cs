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
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.UseCases, opt => opt.MapFrom(src => Constant.USER.Select(x => new UserUseCase { UseCaseId = x }).ToList())); ;

            CreateMap<UpdateUserDTO, User>();

            CreateMap<User, GetUserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar ?? "No profile picture"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Communities, opt => opt.MapFrom(src => src.Communities.Select(x => new GetCommunitiesDTO
                {
                    Id = x.CommunityId,
                    Name = x.Community.Name
                })))
                .ForMember(dest => dest.Followings, opt => opt.MapFrom(src => src.Followings.Select(x => new GetFollowUserInfo
                {
                    Id = x.Id,
                    Username = x.User.Username
                })))
                .ForMember(dest => dest.Followers, opt => opt.MapFrom(src => src.Followers.Select(x => new GetFollowUserInfo
                {
                    Id = x.Id,
                    Username = x.User.Username
                })));

            CreateMap<User, GetUsersDTO>()
               .ForMember(dest => dest.FullName,
                   opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
               .ForMember(dest => dest.Reactions,
                   opt => opt.MapFrom(src => src.Reactions.Count))
               .ForMember(dest => dest.Followers,
                   opt => opt.MapFrom(src => src.Followers.Count))
               .ForMember(dest => dest.Followings,
                   opt => opt.MapFrom(src => src.Followings.Count))
               .ForMember(dest => dest.Answers,
                   opt => opt.MapFrom(src => src.Answers.Count))
               .ForMember(dest => dest.Questions,
                   opt => opt.MapFrom(src => src.Questions.Count))
               .ForMember(dest => dest.Communities,
                   opt => opt.MapFrom(src => src.Communities.Select(x => new GetCommunitiesDTO
                   {
                       Id = x.CommunityId,
                       Name = x.Community.Name
                   }).ToList()));
        }
    }
}

