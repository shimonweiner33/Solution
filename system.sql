USE [master]
GO
/****** Object:  Database [Solution]    Script Date: 2021-10-12 1:38:57 PM ******/
CREATE DATABASE [Solution]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Solution', FILENAME = N'D:\SQL_Data\DB\Solution.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Solution_log', FILENAME = N'D:\SQL_Data\DB_Log\Solution_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Solution] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Solution].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Solution] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Solution] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Solution] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Solution] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Solution] SET ARITHABORT OFF 
GO
ALTER DATABASE [Solution] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Solution] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Solution] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Solution] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Solution] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Solution] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Solution] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Solution] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Solution] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Solution] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Solution] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Solution] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Solution] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Solution] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Solution] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Solution] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Solution] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Solution] SET RECOVERY FULL 
GO
ALTER DATABASE [Solution] SET  MULTI_USER 
GO
ALTER DATABASE [Solution] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Solution] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Solution] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Solution] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Solution] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Solution', N'ON'
GO
ALTER DATABASE [Solution] SET QUERY_STORE = OFF
GO
USE [Solution]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Solution]
GO
/****** Object:  Table [dbo].[Acount]    Script Date: 2021-10-12 1:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Acount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](90) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[Disabled] [bit] NULL,
	[AccountExpiresAt] [datetime] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Acount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2021-10-12 1:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](30) NULL,
	[LastName] [nvarchar](30) NULL,
	[PhoneArea] [nvarchar](3) NULL,
	[PhoneNumber] [nvarchar](7) NULL,
	[Gender] [nvarchar](1) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](50) NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Member_1] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Params]    Script Date: 2021-10-12 1:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Params](
	[VIPCapacity] [int] NOT NULL,
	[ValueCapacity] [int] NOT NULL,
	[RegularCapacity] [int] NOT NULL,
	[VIPMinLot] [int] NOT NULL,
	[ValueMinLot] [int] NOT NULL,
	[RegularMinLot] [int] NOT NULL,
	[VIPMaxLot] [int] NOT NULL,
	[ValueMaxLot] [int] NOT NULL,
	[RegularMaxLot] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParkingLots]    Script Date: 2021-10-12 1:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingLots](
	[LotNumber] [int] NOT NULL,
	[TicketType] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_ParkingLots] PRIMARY KEY CLUSTERED 
(
	[LotNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 2021-10-12 1:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[LicencePlateId] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Phone] [nvarchar](10) NULL,
	[TicketType] [int] NOT NULL,
	[VehicleType] [int] NOT NULL,
	[VehicleHeight] [int] NOT NULL,
	[VehicleWidth] [int] NOT NULL,
	[VehicleLength] [int] NOT NULL,
	[LotNumber] [int] NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[LicencePlateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiclesTypes]    Script Date: 2021-10-12 1:38:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiclesTypes](
	[Id] [int] NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Category] [nchar](10) NOT NULL,
 CONSTRAINT [PK_VehiclesTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Acount] ON 

INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (1, N'111', N'3c9d/PiEYW/QvAVFdAQTdOkZmRc=', NULL, NULL, CAST(N'2021-10-08T11:57:16.330' AS DateTime), N'manager', CAST(N'2021-10-08T11:57:16.330' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (2, N'222', N'/yTQh+EI1iVBtFJazuqp08uxilc=', NULL, NULL, CAST(N'2021-10-08T12:47:34.907' AS DateTime), N'manager', CAST(N'2021-10-08T12:47:34.907' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (3, N'444', N'rCb0qjEaNEwgMUCXQkKS+F2zOSs=', NULL, NULL, CAST(N'2021-10-08T13:52:37.620' AS DateTime), N'manager', CAST(N'2021-10-08T13:52:37.620' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (4, N'test', N'W477AMlLwwJQeAGlPZKiEILr8TA=', NULL, NULL, CAST(N'2021-10-10T01:06:15.240' AS DateTime), N'manager', CAST(N'2021-10-10T01:06:15.240' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (5, N'4444', N'C65usSEfU7aFykc6AkdoIVaSqN0=', NULL, NULL, CAST(N'2021-10-12T01:04:51.567' AS DateTime), N'manager', CAST(N'2021-10-12T01:04:51.567' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (6, N'8888', N'Es+qGi+dw7AOKBgTAlXFB0uf0Cc=', NULL, NULL, CAST(N'2021-10-12T01:06:38.120' AS DateTime), N'manager', CAST(N'2021-10-12T01:06:38.120' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (7, N'999', N'X6FjQM+4FdiTZGBjQCtICztSuuE=', NULL, NULL, CAST(N'2021-10-12T01:30:16.700' AS DateTime), N'manager', CAST(N'2021-10-12T01:30:16.700' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (8, N'989', N'T8KwFWPUJMj5rCd17u6YYWbUSRs=', NULL, NULL, CAST(N'2021-10-12T13:07:31.213' AS DateTime), N'manager', CAST(N'2021-10-12T13:07:31.213' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (9, N'665', N'BdsHhrmsdj18I8KlrAZcTVFgodc=', NULL, NULL, CAST(N'2021-10-12T13:11:23.187' AS DateTime), N'manager', CAST(N'2021-10-12T13:11:23.187' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (10, N'1233', N'6EeR1+wXhGmqurAdghjvo36MR+4=', NULL, NULL, CAST(N'2021-10-12T13:13:02.237' AS DateTime), N'manager', CAST(N'2021-10-12T13:13:02.237' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (11, N'3332', N'ogj5j6r3IcQPgKUtsYoCZC638rs=', NULL, NULL, CAST(N'2021-10-12T13:13:37.820' AS DateTime), N'manager', CAST(N'2021-10-12T13:13:37.820' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (12, N'23234', N'eUGZTm2iZpqJGRautV4kjOQUZYk=', NULL, NULL, CAST(N'2021-10-12T13:20:35.937' AS DateTime), N'manager', CAST(N'2021-10-12T13:20:35.937' AS DateTime), N'manager')
INSERT [dbo].[Acount] ([Id], [UserName], [PasswordHash], [Disabled], [AccountExpiresAt], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (13, N'4343', N'mzO746vQoWoKkrmNqGWvHZq2nt8=', NULL, NULL, CAST(N'2021-10-12T13:31:17.953' AS DateTime), N'manager', CAST(N'2021-10-12T13:31:17.953' AS DateTime), N'manager')
SET IDENTITY_INSERT [dbo].[Acount] OFF
GO
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'111', N'111', N'111', N'054', N'333333', NULL, CAST(N'2021-10-08T11:57:16.153' AS DateTime), N'manager', CAST(N'2021-10-08T11:57:16.153' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'1233', N'ron', N'w', N'054', N'3333333', NULL, CAST(N'2021-10-12T13:13:02.233' AS DateTime), N'manager', CAST(N'2021-10-12T13:13:02.233' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'222', N'222', N'222', N'054', N'4444444', NULL, CAST(N'2021-10-08T12:47:34.890' AS DateTime), N'manager', CAST(N'2021-10-08T12:47:34.890' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'23234', N'david', N'ben', N'054', N'4444444', NULL, CAST(N'2021-10-12T13:20:35.933' AS DateTime), N'manager', CAST(N'2021-10-12T13:20:35.933' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'3332', N'ron', N'w', N'054', N'9999999', NULL, CAST(N'2021-10-12T13:13:37.810' AS DateTime), N'manager', CAST(N'2021-10-12T13:13:37.810' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'4343', N'ron', N'w', N'054', N'4444444', NULL, CAST(N'2021-10-12T13:31:17.947' AS DateTime), N'manager', CAST(N'2021-10-12T13:31:17.947' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'444', N'david', N'ben guryon', N'054', N'5666666', NULL, CAST(N'2021-10-08T13:52:37.587' AS DateTime), N'manager', CAST(N'2021-10-08T13:52:37.587' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'4444', N'david', N'hamelech', N'054', N'5999999', NULL, CAST(N'2021-10-12T01:04:51.543' AS DateTime), N'manager', CAST(N'2021-10-12T01:04:51.543' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'665', N's', N'w', N'054', N'4444444', NULL, CAST(N'2021-10-12T13:11:23.183' AS DateTime), N'manager', CAST(N'2021-10-12T13:11:23.183' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'8888', N'erez', N'a', N'054', N'5444444', NULL, CAST(N'2021-10-12T01:06:38.053' AS DateTime), N'manager', CAST(N'2021-10-12T01:06:38.057' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'989', N'don', N'kishot', N'054', N'5999999', NULL, CAST(N'2021-10-12T13:07:31.203' AS DateTime), N'manager', CAST(N'2021-10-12T13:07:31.203' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'999', N'dan', N'shavit', N'054', N'4444444', NULL, CAST(N'2021-10-12T01:30:16.690' AS DateTime), N'manager', CAST(N'2021-10-12T01:30:16.690' AS DateTime), N'manager')
INSERT [dbo].[Member] ([UserName], [FirstName], [LastName], [PhoneArea], [PhoneNumber], [Gender], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'test', N'test', N'aaa', N'054', N'4444444', NULL, CAST(N'2021-10-10T01:06:15.087' AS DateTime), N'manager', CAST(N'2021-10-10T01:06:15.087' AS DateTime), N'manager')
GO
INSERT [dbo].[Params] ([VIPCapacity], [ValueCapacity], [RegularCapacity], [VIPMinLot], [ValueMinLot], [RegularMinLot], [VIPMaxLot], [ValueMaxLot], [RegularMaxLot]) VALUES (10, 20, 30, 1, 11, 31, 10, 30, 60)
GO
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (1, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (2, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (3, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (4, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (5, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (6, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (7, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (8, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (9, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (10, 1, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (11, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (12, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (13, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (14, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (15, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (16, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (17, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (18, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (19, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (20, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (21, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (22, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (23, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (24, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (25, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (26, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (27, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (28, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (29, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (30, 2, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (31, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (32, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (33, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (34, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (35, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (36, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (37, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (38, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (39, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (40, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (41, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (42, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (43, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (44, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (45, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (46, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (47, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (48, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (49, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (50, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (51, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (52, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (53, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (54, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (55, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (56, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (57, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (58, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (59, 3, 0)
INSERT [dbo].[ParkingLots] ([LotNumber], [TicketType], [Status]) VALUES (60, 3, 0)
GO
INSERT [dbo].[VehiclesTypes] ([Id], [Name], [Category]) VALUES (1, N'Motorcycle', N'Class A   ')
INSERT [dbo].[VehiclesTypes] ([Id], [Name], [Category]) VALUES (2, N'Private   ', N'Class A   ')
INSERT [dbo].[VehiclesTypes] ([Id], [Name], [Category]) VALUES (3, N'Crossover ', N'Class A   ')
INSERT [dbo].[VehiclesTypes] ([Id], [Name], [Category]) VALUES (4, N'SUV       ', N'Class B   ')
INSERT [dbo].[VehiclesTypes] ([Id], [Name], [Category]) VALUES (5, N'Van       ', N'Class B   ')
INSERT [dbo].[VehiclesTypes] ([Id], [Name], [Category]) VALUES (6, N'Truck     ', N'Class C   ')
GO
/****** Object:  Index [UQ__Vehicles__F803D249781529D6]    Script Date: 2021-10-12 1:38:58 PM ******/
ALTER TABLE [dbo].[Vehicles] ADD UNIQUE NONCLUSTERED 
(
	[LotNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Params] ADD  CONSTRAINT [DF_ParkingLots_VIPCapacity]  DEFAULT ((10)) FOR [VIPCapacity]
GO
ALTER TABLE [dbo].[Params] ADD  CONSTRAINT [DF_ParkingLots_ValueCapacity]  DEFAULT ((20)) FOR [ValueCapacity]
GO
ALTER TABLE [dbo].[Params] ADD  CONSTRAINT [DF_ParkingLots_RegularCapacity]  DEFAULT ((30)) FOR [RegularCapacity]
GO
ALTER TABLE [dbo].[Params] ADD  CONSTRAINT [DF_Params_VIPCapacity1]  DEFAULT ((1)) FOR [VIPMinLot]
GO
ALTER TABLE [dbo].[Params] ADD  CONSTRAINT [DF_Params_ValueCapacity1]  DEFAULT ((11)) FOR [ValueMinLot]
GO
ALTER TABLE [dbo].[Params] ADD  CONSTRAINT [DF_Params_RegularCapacity1]  DEFAULT ((31)) FOR [RegularMinLot]
GO
ALTER TABLE [dbo].[Params] ADD  CONSTRAINT [DF_Params_VIPMinLot1]  DEFAULT ((10)) FOR [VIPMaxLot]
GO
ALTER TABLE [dbo].[Params] ADD  CONSTRAINT [DF_Params_ValueMinLot1]  DEFAULT ((30)) FOR [ValueMaxLot]
GO
ALTER TABLE [dbo].[Params] ADD  CONSTRAINT [DF_Params_RegularMinLot1]  DEFAULT ((60)) FOR [RegularMaxLot]
GO
ALTER TABLE [dbo].[ParkingLots] ADD  CONSTRAINT [DF_ParkingLots_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD FOREIGN KEY([LotNumber])
REFERENCES [dbo].[ParkingLots] ([LotNumber])
GO
ALTER TABLE [dbo].[Vehicles]  WITH CHECK ADD  CONSTRAINT [FK__Vehicles__Vehicl__300424B4] FOREIGN KEY([VehicleType])
REFERENCES [dbo].[VehiclesTypes] ([Id])
GO
ALTER TABLE [dbo].[Vehicles] CHECK CONSTRAINT [FK__Vehicles__Vehicl__300424B4]
GO
/****** Object:  StoredProcedure [dbo].[CheckIn]    Script Date: 2021-10-12 1:38:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Shimon Weiner
-- Create date: 2021-10-07
-- Description:	the SP insert Vehicle to the ParkingLots - table.
-- Returns the OUTPUT is Vehicles list as JSON object.
-- =============================================
CREATE PROCEDURE [dbo].[CheckIn]
	@licencePlateId INT, 
	@name NVARCHAR(MAX),
	@phone NVARCHAR(MAX),
	@ticketType INT,
	@ticketTypeName NVARCHAR(50) ,	
	@vehicleType INT,
	@vehicleTypeName NVARCHAR(50),
	@vehicleHeight INT,
	@vehicleWidth INT,
	@vehicleLength INT
AS
	--mock data
	--declare @licencePlateId INT  = 4444444
	--declare @name NVARCHAR(MAX) = 'Yehuda'
	--declare @phone NVARCHAR(MAX) = 0545454545
	--declare @ticketType INT = 3
	--declare @ticketTypeName NVARCHAR(50) = 'Regular'
	--declare @vehicleType INT = 1
	--declare @vehicleTypeName NVARCHAR(50) = 'Motorcycle'
	--declare @vehicleHeight INT = 123
	--declare @vehicleWidth INT = 234
	--declare @vehicleLength INT = 2345

    BEGIN
			--get parameters from Params Table
			--DECLARE @freeStatus INT = 0
			--DECLARE @editStatus INT = 1
			DECLARE @occupyStatus INT = 2

			DECLARE @isCheckIn INT = 0
			DROP TABLE IF EXISTS #ParamsTemp
			CREATE TABLE #ParamsTemp(Capacity int, MinLot int, MaxLot int)

			DECLARE @tempQuery VARCHAR(1000)
			SET @tempQuery = 'select ' + @ticketTypeName + 'Capacity, ' + @ticketTypeName + 'MinLot, '+ @ticketTypeName + 'MaxLot '+ 'from Params'
			INSERT INTO #ParamsTemp(Capacity, MinLot, MaxLot)  EXECUTE (@tempQuery)
			-----------------
			DECLARE @capacity INT
			SET @capacity = (select Capacity from #ParamsTemp)
			DECLARE @minLot INT
			SET @minLot = (select MinLot from #ParamsTemp)
			DECLARE @maxLot INT
			SET @maxLot = (select MaxLot from #ParamsTemp)
			    
			DROP TABLE IF EXISTS #LotNumberTemp
			CREATE TABLE #LotNumberTemp(LotNumber int)

			SET NOCOUNT ON;

			INSERT INTO #LotNumberTemp
			SELECT LotNumber FROM Vehicles WHERE TicketType = @ticketType
			---------------
			--UPDATE ParkingLots SET Status = 0
			DECLARE @minLotTable TABLE
			(
			    LotNumber INT NOT NULL
			)
			UPDATE ParkingLots
			SET Status = 1--@editStatus
			OUTPUT INSERTED.LotNumber INTO @minLotTable
			WHERE LotNumber = (SELECT MIN(p.LotNumber)
							   FROM ParkingLots p 
							   LEFT JOIN Vehicles v ON p.LotNumber = v.LotNumber
							   WHERE p.TicketType = @ticketType AND v.LotNumber IS NULL AND Status = 0)
			
----------------------------------------------------------

			  
			 
			DECLARE @minLotNumber INT = (select LotNumber from @minLotTable)
			DECLARE @occupy INT
			SET @occupy = (select count(LicencePlateId) from Vehicles where TicketType = @ticketType)

			IF(@capacity > @occupy AND 
			    NOT EXISTS (SELECT * FROM Vehicles WHERE LicencePlateId = @licencePlateId)
			)
				BEGIN
					BEGIN TRY
						BEGIN TRAN T1;
						      INSERT INTO Vehicles(LicencePlateId, Name, Phone, TicketType, VehicleType, VehicleHeight, VehicleWidth, VehicleLength, LotNumber)
						      VALUES(@licencePlateId, @name, @phone, @ticketType, @vehicleType, @vehicleHeight, @vehicleLength, @vehicleWidth, @minLotNumber);

							  UPDATE ParkingLots
							  SET Status = 2--@occupyStatus
							  WHERE LotNumber = @minLotNumber
							  
							  SET @isCheckIn = 1
						COMMIT TRAN T1; 
					END TRY
					BEGIN CATCH
						UPDATE ParkingLots
						SET Status = 0
						WHERE LotNumber = @minLotNumber
						SET @isCheckIn = 0
					    
						ROLLBACK
					END CATCH
				END 
			ELSE
				BEGIN
					  UPDATE ParkingLots
					  SET Status = 0
					  WHERE LotNumber = @minLotNumber
					  SET @isCheckIn = 0
				END

	  RETURN @isCheckIn;
    END;


GO
/****** Object:  StoredProcedure [dbo].[GetVehiclesByTicketType]    Script Date: 2021-10-12 1:38:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Shimon Weiner
-- Create date: 2021-10-07
-- Description:	the SP Gets Vehicles list filter By TicketType
-- Returns the OUTPUT is Vehicles list as JSON object.
-- =============================================
CREATE PROCEDURE [dbo].[GetVehiclesByTicketType]
	@ticketType INT = NULL,
	@jsonResult NVARCHAR(MAX) OUTPUT
AS
--declare @ticketType INT = NULL
--declare @jsonResult NVARCHAR(MAX)
BEGIN

	SET NOCOUNT ON;
	SET @jsonResult = (
			SELECT 
				 [LicencePlateId]
				,[Name]
				,[Phone]
				,p.[TicketType]
				,[VehicleType]
				,[VehicleHeight]
				,[VehicleWidth]
				,[VehicleLength]
				,p.[LotNumber]
			FROM ParkingLots AS p
			LEFT JOIN Vehicles v on p.LotNumber = v.LotNumber
			WHERE @ticketType IS NULL OR p.TicketType = @ticketType ORDER BY LotNumber
		FOR JSON PATH, ROOT('Vehicles'), INCLUDE_NULL_VALUES)
END
select @jsonResult

GO
USE [master]
GO
ALTER DATABASE [Solution] SET  READ_WRITE 
GO
