USE [master]
GO
/****** Object:  Database [AdminAng5DB]    Script Date: 2019-05-27 4:19:42 PM ******/
CREATE DATABASE [AdminAng5DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AdminAng5DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS1\MSSQL\DATA\AdminAng5DB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AdminAng5DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS1\MSSQL\DATA\AdminAng5DB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AdminAng5DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AdminAng5DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AdminAng5DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AdminAng5DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AdminAng5DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AdminAng5DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AdminAng5DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AdminAng5DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AdminAng5DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AdminAng5DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AdminAng5DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AdminAng5DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AdminAng5DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AdminAng5DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AdminAng5DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AdminAng5DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AdminAng5DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AdminAng5DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AdminAng5DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AdminAng5DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AdminAng5DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AdminAng5DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AdminAng5DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AdminAng5DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AdminAng5DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AdminAng5DB] SET  MULTI_USER 
GO
ALTER DATABASE [AdminAng5DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AdminAng5DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AdminAng5DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AdminAng5DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AdminAng5DB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [AdminAng5DB]
GO
/****** Object:  Table [dbo].[AdminLogins]    Script Date: 2019-05-27 4:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminLogins](
	[AdminId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Mobileno] [nvarchar](25) NULL,
	[IsActive] [bit] NOT NULL,
	[LastLogin] [datetime] NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifyBy] [int] NULL,
	[ModifyDate] [datetime] NULL,
	[DeletedBy] [int] NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_AdminLogins] PRIMARY KEY CLUSTERED 
(
	[AdminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CountryMaster]    Script Date: 2019-05-27 4:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CountryMaster](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CountryMaster] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CurrencyMaster]    Script Date: 2019-05-27 4:19:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CurrencyMaster](
	[CurrencyId] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [varchar](225) NULL,
	[IsActive] [bit] NULL,
	[IsBase] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CurrencyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AdminLogins] ON 

INSERT [dbo].[AdminLogins] ([AdminId], [Username], [Password], [FirstName], [LastName], [Email], [Mobileno], [IsActive], [LastLogin], [CreatedBy], [CreatedDate], [ModifyBy], [ModifyDate], [DeletedBy], [DeletedDate]) VALUES (1, N'admin', N'admin', N'Admin', N'Admin', N'Admin@gmail.com', N'9033574764', 1, CAST(N'2012-01-01 00:00:00.000' AS DateTime), 1, CAST(N'2012-01-01 00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[AdminLogins] OFF
SET IDENTITY_INSERT [dbo].[CountryMaster] ON 

INSERT [dbo].[CountryMaster] ([CountryId], [CountryName], [IsActive]) VALUES (1, N'India', 1)
INSERT [dbo].[CountryMaster] ([CountryId], [CountryName], [IsActive]) VALUES (2, N'Canada', 1)
SET IDENTITY_INSERT [dbo].[CountryMaster] OFF
SET IDENTITY_INSERT [dbo].[CurrencyMaster] ON 

INSERT [dbo].[CurrencyMaster] ([CurrencyId], [CurrencyName], [IsActive], [IsBase]) VALUES (1, N'$', 1, NULL)
INSERT [dbo].[CurrencyMaster] ([CurrencyId], [CurrencyName], [IsActive], [IsBase]) VALUES (2, N'Rs.', 1, NULL)
SET IDENTITY_INSERT [dbo].[CurrencyMaster] OFF
USE [master]
GO
ALTER DATABASE [AdminAng5DB] SET  READ_WRITE 
GO
