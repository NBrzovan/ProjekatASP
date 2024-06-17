using SocialPlatform.Application.UseCases.Answers;
using SocialPlatform.Application.UseCases.Communities;
using SocialPlatform.Application.UseCases.Followings;
using SocialPlatform.Application.UseCases.Logs;
using SocialPlatform.Application.UseCases.Questions;
using SocialPlatform.Application.UseCases.Reactions;
using SocialPlatform.Application.UseCases.Tags;
using SocialPlatform.Application.UseCases.Topics;
using SocialPlatform.Application.UseCases.Users;
using SocialPlatform.Implementation.UseCases.Answers;
using SocialPlatform.Implementation.UseCases.Communities;
using SocialPlatform.Implementation.UseCases.Followings;
using SocialPlatform.Implementation.UseCases.Logs;
using SocialPlatform.Implementation.UseCases.Questions;
using SocialPlatform.Implementation.UseCases.Reactions;
using SocialPlatform.Implementation.UseCases.Tags;
using SocialPlatform.Implementation.UseCases.Topics;
using SocialPlatform.Implementation.UseCases.Users;
using SocialPlatform.Implementation.Validators.Answers;
using SocialPlatform.Implementation.Validators.Questions;
using SocialPlatform.Implementation.Validators.Topics;
using SocialPlatform.Implementation.Validators.Users;
using SocialPlatform.Implementation.Validators;

namespace SocialPlatform.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUsecaseAndValidator(this IServiceCollection services)
        {
            services.AddTransient<ICreateTopicCommand, EfCreateTopicCommand>();
            services.AddTransient<IDeleteTopicCommand, EfDeleteTopicCommand>();
            services.AddTransient<ICreateCommunityCommand, EfCreateCommunityCommand>();
            services.AddTransient<IDeleteCommunityCommand, EfDeleteCommunityCommand>();
            services.AddTransient<ICreateTagCommand, EfCreateTagCommand>();
            services.AddTransient<IDeleteTagCommand, EfDeleteTagCommand>();
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<ICreateQuestionCommand, EfCreateQuestionCommand>();
            services.AddTransient<IUpdateQuestionCommand, EfUpdateQuestionCommand>();
            services.AddTransient<IDeleteQuestionCommand, EfDeleteQuestionCommand>();
            services.AddTransient<ICreateAnswerCommand, EfCreateAnswerCommand>();
            services.AddTransient<IUpdateAnswerCommand, EfUpdateAnswerCommand>();
            services.AddTransient<IDeleteAnswerCommand, EfDeleteAnswerCommand>();
            services.AddTransient<ICreateFollowCommand, EfCreateFollowCommand>();
            services.AddTransient<IDeleteFollowCommand, EfDeleteFollowCommand>();
            services.AddTransient<ICreateFollowCommunityCommand, EfCreateFollowCommunityCommand>();
            services.AddTransient<IDeleteFollowCommunityCommand, EfDeleteFollowCommunityCommand>();
            services.AddTransient<ICreateLikeReactionCommand, EfCreateLikeReactionCommand>();
            services.AddTransient<ICreateDislikeReactionCommand, EfCreateDislikeReactionCommand>();
            services.AddTransient<IDeleteReactionCommand, EfDeleteReactionCommand>();
            services.AddTransient<IUpdateUserAccessCommand, EfUpdateUserAccessCommand>();

            services.AddTransient<IGetTopicsQuery, EfGetTopicsQuery>();
            services.AddTransient<IGetCommunitiesQuery, EfGetCommunitiesQuery>();
            services.AddTransient<IGetTagsQuery, EfGetTagsQuery>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetQuestionQuery, EfGetQuestionQuery>();
            services.AddTransient<IGetQuestionsQuery, EfGetQuestionsQuery>();
            services.AddTransient<IGetErrorLogQuery, EfGetErrorLogQuery>();
            services.AddTransient<IGetUseCaseLogsQuery, EfGetUseCaseLogsQuery>();

            services.AddTransient<CreateTopicDTOValidator>();
            services.AddTransient<CreateCommunityDTOValidator>();
            services.AddTransient<CreateTagDTOValidator>();
            services.AddTransient<CreateUserDTOValidator>();
            services.AddTransient<UpdateUserDTOValidator>();
            services.AddTransient<CreateQuestionDTOValidator>();
            services.AddTransient<UpdateQuestionDTOValidator>();
            services.AddTransient<CreateAnswerDTOValidator>();
            services.AddTransient<UpdateAnswerDTOValidator>();
            services.AddTransient<CreateFollowDTOValidator>();
            services.AddTransient<CreateFollowCommunityDTOValidator>();
            services.AddTransient<CreateReactionDTOValidator>();
            services.AddTransient<UpdateUserAccessDtoValidator>();

        }
    }
}

