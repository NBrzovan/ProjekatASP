USE [master]
GO
/****** Object:  Database [socialplatform]    Script Date: 6/17/2024 8:35:44 PM ******/
CREATE DATABASE [socialplatform]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'socialplatform', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\socialplatform.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'socialplatform_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\socialplatform_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [socialplatform] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [socialplatform].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [socialplatform] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [socialplatform] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [socialplatform] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [socialplatform] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [socialplatform] SET ARITHABORT OFF 
GO
ALTER DATABASE [socialplatform] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [socialplatform] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [socialplatform] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [socialplatform] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [socialplatform] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [socialplatform] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [socialplatform] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [socialplatform] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [socialplatform] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [socialplatform] SET  DISABLE_BROKER 
GO
ALTER DATABASE [socialplatform] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [socialplatform] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [socialplatform] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [socialplatform] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [socialplatform] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [socialplatform] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [socialplatform] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [socialplatform] SET RECOVERY FULL 
GO
ALTER DATABASE [socialplatform] SET  MULTI_USER 
GO
ALTER DATABASE [socialplatform] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [socialplatform] SET DB_CHAINING OFF 
GO
ALTER DATABASE [socialplatform] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [socialplatform] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [socialplatform] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [socialplatform] SET QUERY_STORE = OFF
GO
USE [socialplatform]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ParentId] [int] NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Communities]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Communities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Communities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLogs]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLogs](
	[ErrorId] [uniqueidentifier] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[StrackTrace] [nvarchar](max) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ErrorLogs] PRIMARY KEY CLUSTERED 
(
	[ErrorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follows]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FollowerId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Follows] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CommunityId] [int] NOT NULL,
	[TopicId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Excerpt] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionTags]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionTags](
	[QuestionId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_QuestionTags] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC,
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reactions]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[QuestionId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ReactionType] [bit] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Reactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topics]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UseCaseName] [nvarchar](50) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[UseCaseData] [nvarchar](max) NOT NULL,
	[ExecutedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCommunities]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCommunities](
	[UserId] [int] NOT NULL,
	[CommunityId] [int] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserCommunities] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[CommunityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCases]    Script Date: 6/17/2024 8:35:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCases](
	[UserId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
	[DeletedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserUseCases] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[UseCaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240612173831_initial_migration', N'8.0.5')
SET IDENTITY_INSERT [dbo].[Communities] ON 

INSERT [dbo].[Communities] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (1, N'TechTalks', CAST(N'2024-06-12T20:07:12.4433333' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Communities] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (2, N'Fitness Fanatics', CAST(N'2024-06-12T20:07:17.9066667' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Communities] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (3, N'DIY Masters', CAST(N'2024-06-12T20:07:21.3333333' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Communities] OFF
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([Id], [CommunityId], [TopicId], [UserId], [Title], [Excerpt], [Body], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (1, 1, 1, 2, N'Kako napraviti DTO?', N'Pitanje o kreiranju DTO objekata', N'Kako bih mogao kreirati DTO objekte u C#? Da li postoji neki dobar pristup za ovo?', CAST(N'2024-06-16T14:49:14.0927498' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Questions] OFF
INSERT [dbo].[QuestionTags] ([QuestionId], [TagId], [DeletedAt], [IsDeleted]) VALUES (1, 1, NULL, 0)
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [Name], [Description], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (1, N'funny', N'Humorous content, jokes, and memes.', CAST(N'2024-06-12T20:05:21.2800000' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Tags] ([Id], [Name], [Description], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (2, N'careeradvice', N'Career tips, professional development advice, job search strategies, and career advancement guidance', CAST(N'2024-06-12T20:05:44.0166667' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Tags] ([Id], [Name], [Description], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (3, N'education', N'Learning tips, discussions on educational policies, teaching methods, and school systems', CAST(N'2024-06-12T20:06:18.2366667' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Tags] OFF
SET IDENTITY_INSERT [dbo].[Topics] ON 

INSERT [dbo].[Topics] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (1, N'Politics', CAST(N'2024-06-12T18:01:52.8090093' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Topics] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (2, N'Music', CAST(N'2024-06-12T18:02:05.6548932' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Topics] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (3, N'Books', CAST(N'2024-06-12T18:02:20.3957237' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Topics] ([Id], [Name], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (4, N'News', CAST(N'2024-06-12T18:02:30.9364621' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Topics] OFF
SET IDENTITY_INSERT [dbo].[UseCaseLogs] ON 

INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (12, N'EfCreateQuestionCommand', N'luke123', N'{"CommunityId":0,"TopicId":1,"Title":"Kako napraviti DTO?","Excerpt":"Pitanje o kreiranju DTO objekata","Body":"Kako bih mogao kreirati DTO objekte u C#? Da li postoji neki dobar pristup za ovo?","TagIds":[1,2]}', CAST(N'2024-06-16T14:43:16.6916340' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (15, N'EfCreateQuestionCommand', N'luke123', N'{"CommunityId":1,"TopicId":1,"Title":"Kako napraviti DTO?","Excerpt":"Pitanje o kreiranju DTO objekata","Body":"Kako bih mogao kreirati DTO objekte u C#? Da li postoji neki dobar pristup za ovo?","TagIds":[1]}', CAST(N'2024-06-16T14:45:26.9617429' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (16, N'EfCreateQuestionCommand', N'luke123', N'{"CommunityId":1,"TopicId":1,"Title":"Kako napraviti DTO?","Excerpt":"Pitanje o kreiranju DTO objekata","Body":"Kako bih mogao kreirati DTO objekte u C#? Da li postoji neki dobar pristup za ovo?","TagIds":[1]}', CAST(N'2024-06-16T14:49:13.6746822' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (2, N'EfCreateTopicCommand', N'nikola123', N'{"Name":"Politics"}', CAST(N'2024-06-12T18:01:52.3725978' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (3, N'EfCreateTopicCommand', N'nikola123', N'{"Name":"Music"}', CAST(N'2024-06-12T18:02:05.6327021' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (4, N'EfCreateTopicCommand', N'nikola123', N'{"Name":"Books"}', CAST(N'2024-06-12T18:02:20.3863571' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (5, N'EfCreateTopicCommand', N'nikola123', N'{"Name":"News"}', CAST(N'2024-06-12T18:02:30.9278388' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (19, N'EfGetUseCaseLogsQuery', N'nikola123', N'{"Keyword":null,"Identity":null,"DateStart":null,"DateEnd":null,"PerPage":10,"Page":1}', CAST(N'2024-06-16T15:08:01.8922476' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (9, N'EfUpdateUserAccessCommand', N'nikola123', N'{"UserId":2,"UseCaseIds":[1]}', CAST(N'2024-06-12T18:11:06.0272326' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (1, N'EfCreateUserCommand', N'unauthorized', N'{"File":null,"FirstName":"Nikola","LastName":"Brzovan","Avatar":null,"Username":"nikola123","Email":"nikola@gmail.com","Password":"nikola123"}', CAST(N'2024-06-12T17:57:43.7827666' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (6, N'EfCreateUserCommand', N'unauthorized', N'{"File":null,"FirstName":"Test","LastName":"Test","Avatar":null,"Username":"testtest","Email":"test@mail.com","Password":"test123"}', CAST(N'2024-06-12T18:09:12.0838137' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (7, N'EfCreateUserCommand', N'unauthorized', N'{"File":null,"FirstName":"Test","LastName":"Test","Avatar":null,"Username":"test60","Email":"test@mail.com","Password":"lozinka123"}', CAST(N'2024-06-12T18:09:43.7560814' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (8, N'EfCreateUserCommand', N'unauthorized', N'{"File":null,"FirstName":"Test","LastName":"Nikolic","Avatar":null,"Username":"test60","Email":"test@mail.com","Password":"lozinka123"}', CAST(N'2024-06-12T18:09:59.7132523' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (11, N'EfCreateUserCommand', N'unauthorized', N'{"File":null,"FirstName":"Luka","LastName":"Lukic","Avatar":null,"Username":"luke123","Email":"lukalukic@gmail.com","Password":"lukaluka123"}', CAST(N'2024-06-16T14:39:18.4500818' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (18, N'EfCreateUserCommand', N'unauthorized', N'{"File":{"ContentDisposition":"form-data; name=\"File\"; filename=\"adminAna.jpg\"","ContentType":"image/jpeg","Headers":{"Content-Disposition":["form-data; name=\"File\"; filename=\"adminAna.jpg\""],"Content-Type":["image/jpeg"]},"Length":152066,"Name":"File","FileName":"adminAna.jpg"},"FirstName":"Barbara","LastName":"Bobak","Avatar":"b607b1a0-d4a9-4e51-8392-8326c82cb6d0.jpg","Username":"bobak123","Email":"barbara@gmail.com","Password":"bobak123"}', CAST(N'2024-06-16T14:52:33.3349931' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (13, N'EfGetCommunitiesQuery', N'unauthorized', N'{"PerPage":10,"Page":1}', CAST(N'2024-06-16T14:44:41.1586623' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (17, N'EfGetQuestionsQuery', N'unauthorized', N'{"UserId":null,"Keywords":null,"TagIds":null,"TopicIds":null,"CommunityId":null,"DateFrom":null,"DateTo":null,"PerPage":10,"Page":1}', CAST(N'2024-06-16T14:49:27.7497005' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (10, N'EfGetTagsQuery', N'unauthorized', N'{"PerPage":10,"Page":1}', CAST(N'2024-06-16T14:28:06.5334467' AS DateTime2))
INSERT [dbo].[UseCaseLogs] ([Id], [UseCaseName], [Username], [UseCaseData], [ExecutedAt]) VALUES (14, N'EfGetTagsQuery', N'unauthorized', N'{"PerPage":10,"Page":1}', CAST(N'2024-06-16T14:45:13.9989032' AS DateTime2))
SET IDENTITY_INSERT [dbo].[UseCaseLogs] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Avatar], [Username], [Email], [Password], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (1, N'Nikola', N'Brzovan', NULL, N'nikola123', N'nikola@gmail.com', N'$2b$10$qTe8i6hxz5ExIkLq3i9HPeODtzwwbat4QgKfmY1Yq4sJbBC5DWkp.', CAST(N'2024-06-12T17:57:46.7688850' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Avatar], [Username], [Email], [Password], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (2, N'Luka', N'Lukic', NULL, N'luke123', N'lukalukic@gmail.com', N'$2b$10$QeGEPrY17Zlux3HEHchoROINWxWHI.LqhPtFt/EHnb.YFBZ8.FO5q', CAST(N'2024-06-16T14:39:20.8028389' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Avatar], [Username], [Email], [Password], [CreatedAt], [UpdatedAt], [DeletedAt], [IsDeleted]) VALUES (3, N'Barbara', N'Bobak', N'b607b1a0-d4a9-4e51-8392-8326c82cb6d0.jpg', N'bobak123', N'barbara@gmail.com', N'$2b$10$evPLRg5cFBEASv01ZX1Mpe0RfNR9MOkjbCD5Aw7GCNHXKN.N/cWLC', CAST(N'2024-06-16T14:52:33.5774711' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 1, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 2, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 3, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 4, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 5, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 6, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 7, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 8, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 9, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 13, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 14, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 18, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 19, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 29, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 30, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 31, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (1, 34, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 6, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 9, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 11, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 12, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 13, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 14, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 15, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 16, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 17, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 18, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 19, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 20, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 21, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 22, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 23, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 24, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 25, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 26, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 27, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 28, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (2, 32, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 6, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 9, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 11, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 12, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 13, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 14, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 15, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 16, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 17, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 18, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 19, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 20, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 21, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 22, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 23, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 24, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 25, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 26, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 27, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 28, NULL, 0)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId], [DeletedAt], [IsDeleted]) VALUES (3, 32, NULL, 0)
/****** Object:  Index [IX_Answers_ParentId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Answers_ParentId] ON [dbo].[Answers]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Answers_QuestionId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Answers_QuestionId] ON [dbo].[Answers]
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Answers_UserId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Answers_UserId] ON [dbo].[Answers]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Follows_FollowerId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Follows_FollowerId] ON [dbo].[Follows]
(
	[FollowerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Follows_UserId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Follows_UserId] ON [dbo].[Follows]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Questions_CommunityId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Questions_CommunityId] ON [dbo].[Questions]
(
	[CommunityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Questions_TopicId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Questions_TopicId] ON [dbo].[Questions]
(
	[TopicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Questions_UserId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Questions_UserId] ON [dbo].[Questions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_QuestionTags_TagId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_QuestionTags_TagId] ON [dbo].[QuestionTags]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reactions_QuestionId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reactions_QuestionId] ON [dbo].[Reactions]
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reactions_UserId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_Reactions_UserId] ON [dbo].[Reactions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UseCaseLogs_Username_UseCaseName_ExecutedAt]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_UseCaseLogs_Username_UseCaseName_ExecutedAt] ON [dbo].[UseCaseLogs]
(
	[Username] ASC,
	[UseCaseName] ASC,
	[ExecutedAt] ASC
)
INCLUDE([UseCaseData]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserCommunities_CommunityId]    Script Date: 6/17/2024 8:35:45 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserCommunities_CommunityId] ON [dbo].[UserCommunities]
(
	[CommunityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Answers] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Answers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Communities] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Communities] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Follows] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Follows] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Questions] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Questions] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Reactions] ADD  DEFAULT (CONVERT([bit],(1))) FOR [ReactionType]
GO
ALTER TABLE [dbo].[Reactions] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Reactions] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Tags] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Tags] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Topics] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Topics] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Answers_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Answers] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Answers_ParentId]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions_QuestionId]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Users_UserId]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_Users_FollowerId] FOREIGN KEY([FollowerId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_Users_FollowerId]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_Users_UserId]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Communities_CommunityId] FOREIGN KEY([CommunityId])
REFERENCES [dbo].[Communities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Communities_CommunityId]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Topics_TopicId] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topics] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Topics_TopicId]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Users_UserId]
GO
ALTER TABLE [dbo].[QuestionTags]  WITH CHECK ADD  CONSTRAINT [FK_QuestionTags_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuestionTags] CHECK CONSTRAINT [FK_QuestionTags_Questions_QuestionId]
GO
ALTER TABLE [dbo].[QuestionTags]  WITH CHECK ADD  CONSTRAINT [FK_QuestionTags_Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuestionTags] CHECK CONSTRAINT [FK_QuestionTags_Tags_TagId]
GO
ALTER TABLE [dbo].[Reactions]  WITH CHECK ADD  CONSTRAINT [FK_Reactions_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reactions] CHECK CONSTRAINT [FK_Reactions_Questions_QuestionId]
GO
ALTER TABLE [dbo].[Reactions]  WITH CHECK ADD  CONSTRAINT [FK_Reactions_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Reactions] CHECK CONSTRAINT [FK_Reactions_Users_UserId]
GO
ALTER TABLE [dbo].[UserCommunities]  WITH CHECK ADD  CONSTRAINT [FK_UserCommunities_Communities_CommunityId] FOREIGN KEY([CommunityId])
REFERENCES [dbo].[Communities] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserCommunities] CHECK CONSTRAINT [FK_UserCommunities_Communities_CommunityId]
GO
ALTER TABLE [dbo].[UserCommunities]  WITH CHECK ADD  CONSTRAINT [FK_UserCommunities_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserCommunities] CHECK CONSTRAINT [FK_UserCommunities_Users_UserId]
GO
ALTER TABLE [dbo].[UserUseCases]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCases_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserUseCases] CHECK CONSTRAINT [FK_UserUseCases_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [socialplatform] SET  READ_WRITE 
GO
