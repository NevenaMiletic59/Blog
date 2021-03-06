USE [master]
GO
/****** Object:  Database [Blog]    Script Date: 7/1/2020 11:52:39 PM ******/
CREATE DATABASE [Blog]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Blog', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\Blog.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Blog_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS01\MSSQL\DATA\Blog_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Blog] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Blog].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Blog] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Blog] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Blog] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Blog] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Blog] SET ARITHABORT OFF 
GO
ALTER DATABASE [Blog] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Blog] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Blog] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Blog] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Blog] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Blog] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Blog] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Blog] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Blog] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Blog] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Blog] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Blog] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Blog] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Blog] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Blog] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Blog] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Blog] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Blog] SET  MULTI_USER 
GO
ALTER DATABASE [Blog] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Blog] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Blog] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Blog] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Blog] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Blog] SET QUERY_STORE = OFF
GO
USE [Blog]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/1/2020 11:52:40 PM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 7/1/2020 11:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[deleted] [bit] NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 7/1/2020 11:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[deleted] [bit] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[postId] [int] NULL,
	[IdPost] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manues]    Script Date: 7/1/2020 11:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manues](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[deleted] [bit] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[href] [nvarchar](max) NULL,
 CONSTRAINT [PK_Manues] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 7/1/2020 11:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[deleted] [bit] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[postId] [int] NULL,
	[IdPost] [int] NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 7/1/2020 11:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[deleted] [bit] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[CetegoryId] [int] NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeUser]    Script Date: 7/1/2020 11:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[deleted] [bit] NOT NULL,
	[Type] [nvarchar](max) NULL,
 CONSTRAINT [PK_TypeUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 7/1/2020 11:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[UseCaseName] [nvarchar](max) NULL,
	[Data] [nvarchar](max) NULL,
	[Actor] [nvarchar](max) NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/1/2020 11:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NULL,
	[deleted] [bit] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[userTypeId] [int] NULL,
	[IdType] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCase]    Script Date: 7/1/2020 11:52:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UseCaseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserUseCase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200625110043_initial', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200625110248_new', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200625112333_f', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200625112517_l', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200625112726_d', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200627153113_add', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200628194011_create-users', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200629163228_create-categories', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200629181316_add-menu', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200630104708_add- comments', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200630144958_add-picture', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200630160529_usecase log', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200630182714_add-userusecase', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200701070424_n', N'3.1.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200701070627_new', N'3.1.5')
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [CreatedAt], [deleted], [CategoryName]) VALUES (1, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Fashion')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [deleted], [CategoryName]) VALUES (2, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Sport')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [deleted], [CategoryName]) VALUES (4, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Life')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [deleted], [CategoryName]) VALUES (5, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Family')
INSERT [dbo].[Categories] ([Id], [CreatedAt], [deleted], [CategoryName]) VALUES (6, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Food')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (1, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Beautiful', 1, 1, 7)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (2, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Good', 1, 1, 8)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (3, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Noot bad', 2, 2, 5)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (4, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Nice', 2, 2, 6)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (14, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Good', 6, 6, 4)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (15, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Wah', 7, 7, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (16, CAST(N'2020-06-01T00:00:00.0000000' AS DateTime2), 0, N'Jol', 8, 8, 1)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (17, CAST(N'2020-06-01T00:00:00.0000000' AS DateTime2), 0, N'Ugh', 9, 9, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (18, CAST(N'2020-03-03T00:00:00.0000000' AS DateTime2), 0, N'Lala', 10, 10, 6)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (20, CAST(N'2020-06-05T00:00:00.0000000' AS DateTime2), 0, N'Mik', 11, 11, 7)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (21, CAST(N'2020-06-07T00:00:00.0000000' AS DateTime2), 0, N'More', 12, 12, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (22, CAST(N'2020-06-07T00:00:00.0000000' AS DateTime2), 0, N'Ugh', 13, 13, 5)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (23, CAST(N'2020-06-01T00:00:00.0000000' AS DateTime2), 0, N'In love', 15, 15, 1)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (24, CAST(N'2020-05-02T00:00:00.0000000' AS DateTime2), 0, N'Good', 16, 16, 3)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (25, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'No', 17, 17, 5)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (26, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Yes', 18, 18, 4)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (27, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'no', 19, 19, 5)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (28, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'cw', 20, 20, 2)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (32, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Ni', 20, 20, 8)
INSERT [dbo].[Comments] ([Id], [CreatedAt], [deleted], [Comment], [postId], [IdPost], [UserId]) VALUES (33, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Yes', 18, 18, 7)
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Manues] ON 

INSERT [dbo].[Manues] ([Id], [CreatedAt], [deleted], [Name], [href]) VALUES (1, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Home', N'home')
INSERT [dbo].[Manues] ([Id], [CreatedAt], [deleted], [Name], [href]) VALUES (2, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Contact', N'contact')
INSERT [dbo].[Manues] ([Id], [CreatedAt], [deleted], [Name], [href]) VALUES (3, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Admin', N'admin')
INSERT [dbo].[Manues] ([Id], [CreatedAt], [deleted], [Name], [href]) VALUES (4, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'One post', N'onePost')
INSERT [dbo].[Manues] ([Id], [CreatedAt], [deleted], [Name], [href]) VALUES (5, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Registration', N'registration')
SET IDENTITY_INSERT [dbo].[Manues] OFF
SET IDENTITY_INSERT [dbo].[Pictures] ON 

INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (5, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika1.jpg', 1, 1)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (6, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika2.jpg', 2, 2)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (9, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika3.jpg', 5, 5)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (11, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika4.jpg', 6, 6)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (12, CAST(N'2020-06-01T00:00:00.0000000' AS DateTime2), 0, N'slika5.jpg', 7, 7)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (13, CAST(N'2020-06-03T00:00:00.0000000' AS DateTime2), 0, N'slika6.jpg', 8, 8)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (14, CAST(N'2020-06-04T00:00:00.0000000' AS DateTime2), 0, N'slika7.jpg', 9, 9)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (15, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika8.jpg', 10, 10)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (16, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika9.jpg', 11, 11)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (18, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika10.jpg', 12, 12)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (19, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika11.jpg', 13, 13)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (20, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika12.jpg', 14, 14)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (21, CAST(N'0202-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika13.jpg', 15, 15)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (22, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika14.jpg', 16, 16)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (23, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika15.jpg', 17, 17)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (24, CAST(N'2020-06-01T00:00:00.0000000' AS DateTime2), 0, N'slika16.jpg', 18, 18)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (25, CAST(N'2020-06-01T00:00:00.0000000' AS DateTime2), 0, N'slika17.jpg', 19, 19)
INSERT [dbo].[Pictures] ([Id], [CreatedAt], [deleted], [Name], [postId], [IdPost]) VALUES (26, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'slika18.jpg', 20, 20)
SET IDENTITY_INSERT [dbo].[Pictures] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (1, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Opis 1 ', N'Naslov 1', 8, 1, 1)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (2, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Opis 2', N'Something new', 8, 2, 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (5, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Description 1', N'Better life', 8, 4, 4)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (6, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Sport is better', N'Everything is better with sport', 8, 2, 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (7, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Learning about family', N'Different life', 8, 5, 5)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (8, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Nothing new', N'Missing time', 8, 1, 1)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (9, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Description 3 ', N'"Maravilloso"', 7, 5, 5)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (10, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Naslov 5', N'Cooking with us', 8, 1, 1)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (11, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Critical', N'Everybody has this', 8, 5, 5)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (12, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Sport ', N'Spotr is life', 8, 2, 2)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (13, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Morning', N'For better morning', 8, 1, 1)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (14, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Dinner', N'This you should try', 8, 6, 6)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (15, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Marinada', N'Try this', 8, 6, 6)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (16, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Ready', N'Run', 8, 4, 4)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (17, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Get ', N'Missing', 8, 4, 4)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (18, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Description 8', N'Something writing', 8, 5, 5)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (19, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Coming', N'Something new', 8, 1, 1)
INSERT [dbo].[Posts] ([Id], [CreatedAt], [deleted], [Description], [Name], [UserId], [CategoryId], [CetegoryId]) VALUES (20, CAST(N'2020-06-30T00:00:00.0000000' AS DateTime2), 0, N'Be rich', N'Be rich without money', 8, 1, 1)
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[UseCaseLogs] ON 

INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (1, CAST(N'2020-06-30T17:50:55.9906841' AS DateTime2), N'Registration user', N'{"FirstName":"Nevena","LastName":"Miletic","Username":"Nevena","Password":"sifra","Email":"nevena@gmail.com"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (2, CAST(N'2020-06-30T17:53:26.7528134' AS DateTime2), N'Registration user', N'{"FirstName":"Nevena","LastName":"Miletic","Username":"Nevena","Password":"sifra","Email":"nevena@gmail.com"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (3, CAST(N'2020-06-30T17:56:22.8319582' AS DateTime2), N'Registration user', N'{"FirstName":"Nevena","LastName":"Miletic","Username":"Nevena","Password":"sifra","Email":"nevena@gmail.com"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (4, CAST(N'2020-06-30T19:10:12.0951620' AS DateTime2), N'Registration user', N'{"FirstName":"Milena","LastName":"Maletic","Username":"Milena","Password":"sifra5","Email":"milena@gmail.com"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (5, CAST(N'2020-06-30T19:13:52.5521200' AS DateTime2), N'Registration user', N'{"FirstName":"Milena","LastName":"Maletic","Username":"Milena","Password":"sifra5","Email":"nevena.miletic.59.17@ict.edu.rs"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (6, CAST(N'2020-06-30T19:14:26.4447582' AS DateTime2), N'Registration user', N'{"FirstName":"Milena","LastName":"Maletic","Username":"Miki","Password":"sifra5","Email":"nevena.miletic.59.17@ict.edu.rs"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (7, CAST(N'2020-06-30T19:15:07.7572652' AS DateTime2), N'Registration user', N'{"FirstName":"Milena","LastName":"Maletic","Username":"Riki","Password":"sifra5","Email":"nenaa.98.miletic@gmail.com"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (8, CAST(N'2020-07-01T06:42:12.5188654' AS DateTime2), N'Registration user', N'{"FirstName":"Marija","LastName":"Peric","Username":"Maja","Password":"marija","Email":"maja@gmail.com"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (9, CAST(N'2020-07-01T06:45:38.1534681' AS DateTime2), N'Registration user', N'{"FirstName":"Marija","LastName":"Peric","Username":"Maja","Password":"marija","Email":"maja@gmail.com"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (10, CAST(N'2020-07-01T06:47:02.8221442' AS DateTime2), N'Registration user', N'{"FirstName":"Milan","LastName":"Maric","Username":"Miki","Password":"malimiki","Email":"miki@gmail.com"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (11, CAST(N'2020-07-01T10:56:11.8298886' AS DateTime2), N'Create new Category', N'{"Id":0,"Name":"Fashion"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (12, CAST(N'2020-07-01T11:06:21.1319158' AS DateTime2), N'Create new Category', N'{"Id":0,"Name":"Fashion"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (13, CAST(N'2020-07-01T11:20:49.3229831' AS DateTime2), N'Registration user', N'{"FirstName":"Admin","LastName":"Admin","Username":"Admin","Password":"admin","Email":"admin@gmail.com"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (14, CAST(N'2020-07-01T15:24:28.0021898' AS DateTime2), N'Create new Category', N'{"Id":0,"Name":"Fashion"}', N'Unauthorized user')
INSERT [dbo].[UseCaseLogs] ([Id], [Date], [UseCaseName], [Data], [Actor]) VALUES (15, CAST(N'2020-07-01T15:28:01.3736227' AS DateTime2), N'Create new Category', N'{"Id":0,"Name":"Fashion"}', N'Unauthorized user')
SET IDENTITY_INSERT [dbo].[UseCaseLogs] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [CreatedAt], [deleted], [FirstName], [LastName], [Username], [Password], [Email], [userTypeId], [IdType]) VALUES (1, NULL, 0, NULL, N'Miletic', N'NevenaM', N'nevena', N'nevena.miletic.59.17@ict.edu.rs', NULL, 0)
INSERT [dbo].[Users] ([Id], [CreatedAt], [deleted], [FirstName], [LastName], [Username], [Password], [Email], [userTypeId], [IdType]) VALUES (2, NULL, 0, NULL, N'Miletic', N'NevenaM', N'nevena', N'nevena.miletic.59.17@ict.edu.rs', NULL, 0)
INSERT [dbo].[Users] ([Id], [CreatedAt], [deleted], [FirstName], [LastName], [Username], [Password], [Email], [userTypeId], [IdType]) VALUES (3, NULL, 0, N'Nevena', N'Miletic', N'Nevena', N'sifra', N'nevena@gmail.com', NULL, 0)
INSERT [dbo].[Users] ([Id], [CreatedAt], [deleted], [FirstName], [LastName], [Username], [Password], [Email], [userTypeId], [IdType]) VALUES (4, NULL, 0, N'Milena', N'Maletic', N'Milena', N'sifra5', N'milena@gmail.com', NULL, 0)
INSERT [dbo].[Users] ([Id], [CreatedAt], [deleted], [FirstName], [LastName], [Username], [Password], [Email], [userTypeId], [IdType]) VALUES (5, NULL, 0, N'Milena', N'Maletic', N'Riki', N'sifra5', N'nenaa.98.miletic@gmail.com', NULL, 0)
INSERT [dbo].[Users] ([Id], [CreatedAt], [deleted], [FirstName], [LastName], [Username], [Password], [Email], [userTypeId], [IdType]) VALUES (6, NULL, 0, N'Marija', N'Peric', N'Maja', N'015ef7cb46d3c512fd27798011b106ec8a3574fd95877a65025cbe836eed75d5', N'maja@gmail.com', NULL, 0)
INSERT [dbo].[Users] ([Id], [CreatedAt], [deleted], [FirstName], [LastName], [Username], [Password], [Email], [userTypeId], [IdType]) VALUES (7, NULL, 0, N'Milan', N'Maric', N'Miki', N'12e504d8496ef8aa548998c48384b65b1310467f9dec9ff390aa72177c514f88', N'miki@gmail.com', NULL, 0)
INSERT [dbo].[Users] ([Id], [CreatedAt], [deleted], [FirstName], [LastName], [Username], [Password], [Email], [userTypeId], [IdType]) VALUES (8, NULL, 0, N'Admin', N'Admin', N'Admin', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'admin@gmail.com', NULL, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UserUseCase] ON 

INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (1, 1, 7)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (2, 7, 7)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (3, 5, 7)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (4, 1, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (5, 7, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (6, 5, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (7, 1, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (8, 2, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (10, 3, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (11, 4, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (12, 6, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (13, 8, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (14, 9, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (15, 10, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (16, 11, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (17, 12, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (18, 13, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (19, 14, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (20, 15, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (21, 16, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (22, 17, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (23, 18, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (24, 19, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (25, 20, 8)
INSERT [dbo].[UserUseCase] ([Id], [UseCaseId], [UserId]) VALUES (26, 21, 8)
SET IDENTITY_INSERT [dbo].[UserUseCase] OFF
/****** Object:  Index [IX_Comments_postId]    Script Date: 7/1/2020 11:52:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_postId] ON [dbo].[Comments]
(
	[postId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_UserId]    Script Date: 7/1/2020 11:52:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_UserId] ON [dbo].[Comments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pictures_postId]    Script Date: 7/1/2020 11:52:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pictures_postId] ON [dbo].[Pictures]
(
	[postId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Posts_CategoryId]    Script Date: 7/1/2020 11:52:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Posts_CategoryId] ON [dbo].[Posts]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Posts_UserId]    Script Date: 7/1/2020 11:52:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Posts_UserId] ON [dbo].[Posts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Users_userTypeId]    Script Date: 7/1/2020 11:52:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_Users_userTypeId] ON [dbo].[Users]
(
	[userTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserUseCase_UserId]    Script Date: 7/1/2020 11:52:42 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserUseCase_UserId] ON [dbo].[UserUseCase]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Posts_postId] FOREIGN KEY([postId])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Posts_postId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Posts_postId] FOREIGN KEY([postId])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Posts_postId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_TypeUser_userTypeId] FOREIGN KEY([userTypeId])
REFERENCES [dbo].[TypeUser] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_TypeUser_userTypeId]
GO
ALTER TABLE [dbo].[UserUseCase]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCase_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserUseCase] CHECK CONSTRAINT [FK_UserUseCase_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [Blog] SET  READ_WRITE 
GO
