USE [master]
GO
/****** Object:  Database [Planner]    Script Date: 01/12/2018 17:44:47 ******/
CREATE DATABASE [Planner]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Planner', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Planner.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Planner_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Planner_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Planner] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Planner].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Planner] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Planner] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Planner] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Planner] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Planner] SET ARITHABORT OFF 
GO
ALTER DATABASE [Planner] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Planner] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Planner] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Planner] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Planner] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Planner] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Planner] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Planner] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Planner] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Planner] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Planner] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Planner] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Planner] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Planner] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Planner] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Planner] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Planner] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Planner] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Planner] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Planner] SET  MULTI_USER 
GO
ALTER DATABASE [Planner] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Planner] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Planner] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Planner] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO


USE [Planner]
GO
/****** Object:  StoredProcedure [dbo].[GetPlannerData]    Script Date: 01/12/2018 17:44:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ilan Shchori
-- Create date: 30/11/2018
-- Description:	Get Planner Data
-- =============================================
CREATE PROCEDURE [dbo].[GetPlannerData] 
	@userId int,
	@start nvarchar(5),
	@end nvarchar(5)

AS
BEGIN
	declare @@user_id int
	declare @@start nvarchar(5)
	declare @@end nvarchar(5)

	if @userId <= 0
		select @@user_id = NULL;
	else		
		select @@user_id = @userId;

	if (@start = '')
	  select @@start = null;
	else
	  select @@start = @start; -- may now be null or non-null, but not ''

	if (@end = '')
	  select @@end = null;
	else
	  select @@end = @end;

	--set @@start = ISNULL(NULLIF(@start, ''), @start);
	--set @@end = ISNULL(NULLIF(@end, ''), @end);

	select	TimeTableId,
			UserId,
			LastRequestDate,
			StartHour,
			EndHour,
			ConnectionCount,
			UsersList 
	from	TimeTable 
	where	(UserId = @@user_id or @@user_id IS NULL)
	and		(StartHour = @@start or @@start IS NULL)
	and		(EndHour = @@end or @@end IS NULL)
	order by StartHour asc
END

GO


/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 01/12/2018 17:44:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ilan Shchori
-- Create date: 30/11/2018
-- Description:	Get Users Data
-- =============================================
CREATE PROCEDURE [dbo].[GetUsers] 
	@userId int,
	@userLogin nvarchar

AS
BEGIN
	DECLARE @@user_id int
	DECLARE @@user_Login nvarchar(50)

	IF @userId <= 0
		SELECT @@user_id = NULL
	ELSE		
		SELECT @@user_id = @userId

	SELECT @@user_Login = '%' + @userLogin + '%'
	SELECT IsConnected,
		UserId, 
		UserName, 
		LoginName, 
		LastConnectionDate 
	FROM  Users 
	WHERE (UserId = @@user_id or @@user_id IS NULL)
	and LoginName like @@user_Login
	order by LastConnectionDate asc
END

GO


/****** Object:  StoredProcedure [dbo].[SchdualeTimeFrame]    Script Date: 01/12/2018 17:44:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Ilan Shchori
-- Create date: 30/11/2018
-- Description:	Mark desired time frame as occupied
-- =============================================
CREATE PROCEDURE [dbo].[SchdualeTimeFrame] 
	@userId int,
	--@userLogin nvarchar,
	@start nvarchar(5),
	@end nvarchar(5),
	@retFlag int OUTPUT

AS
BEGIN
	set @retFlag = 0
	--DECLARE @@user_id int
	--DECLARE @@user_Login nvarchar(50)
	declare @user_name nvarchar(50);
	declare @users_list nvarchar(4000);
	declare @count int;
	declare @ttId int;

	select @user_name = LoginName from dbo.Users where UserId = @userId;
	select	@count = ConnectionCount,
			@ttId = TimeTableId,
			@users_list = UsersList
	from dbo.TimeTable 
	where StartHour = @start and EndHour = @end;
	
	if @users_list is not null
		set @users_list = CONCAT(@users_list, ', ');
	if @ttId > 0
		update dbo.TimeTable 
		set ConnectionCount = @count + 1,
			UsersList = concat(@users_list, @user_name)
		where TimeTableId = @ttId; 
		set @retFlag = @ttId
END

GO


/****** Object:  Table [dbo].[TimeTable]    Script Date: 01/12/2018 17:44:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TimeTable](
	[TimeTableId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[LastRequestDate] [datetime] NULL,
	[StartHour] [nvarchar](5) NULL,
	[EndHour] [nvarchar](5) NULL,
	[ConnectionCount] [smallint] NULL,
	[UsersList] [nvarchar](4000) NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[TimeTableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[Users]    Script Date: 01/12/2018 17:44:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[LoginName] [nvarchar](50) NULL,
	[LastConnectionDate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET IDENTITY_INSERT [dbo].[TimeTable] ON 

INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (1, NULL, NULL, N'07:00', N'08:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (2, NULL, NULL, N'08:00', N'09:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (3, NULL, NULL, N'09:00', N'10:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (4, NULL, NULL, N'10:00', N'11:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (5, NULL, NULL, N'11:00', N'12:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (6, NULL, NULL, N'12:00', N'13:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (7, NULL, NULL, N'13:00', N'14:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (8, NULL, NULL, N'14:00', N'15:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (9, NULL, NULL, N'15:00', N'16:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (10, NULL, NULL, N'16:00', N'17:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (11, NULL, NULL, N'17:00', N'18:00', 0, NULL)
INSERT [dbo].[TimeTable] ([TimeTableId], [UserId], [LastRequestDate], [StartHour], [EndHour], [ConnectionCount], [UsersList]) VALUES (12, NULL, NULL, N'18:00', N'19:00', 0, NULL)
SET IDENTITY_INSERT [dbo].[TimeTable] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [UserName], [LoginName], [LastConnectionDate]) VALUES (1, N'Ilan', N'Ilan', NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [LoginName], [LastConnectionDate]) VALUES (2, N'Steve', N'Steve', NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [LoginName], [LastConnectionDate]) VALUES (3, N'Joe', N'Joe', NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [LoginName], [LastConnectionDate]) VALUES (4, N'Michele', N'Michele', NULL)
INSERT [dbo].[Users] ([UserId], [UserName], [LoginName], [LastConnectionDate]) VALUES (5, N'George', N'George', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF

USE [master]
GO
ALTER DATABASE [Planner] SET  READ_WRITE 
GO
