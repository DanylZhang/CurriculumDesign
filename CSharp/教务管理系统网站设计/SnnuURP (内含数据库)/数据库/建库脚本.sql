USE [master]
GO
/****** Object:  Database [SNNUURPDB]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE DATABASE [SNNUURPDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SNNUURPDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SNNUURPDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SNNUURPDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SNNUURPDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SNNUURPDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SNNUURPDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SNNUURPDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SNNUURPDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SNNUURPDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SNNUURPDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SNNUURPDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SNNUURPDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SNNUURPDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SNNUURPDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SNNUURPDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SNNUURPDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SNNUURPDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SNNUURPDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SNNUURPDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SNNUURPDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SNNUURPDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SNNUURPDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SNNUURPDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SNNUURPDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SNNUURPDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SNNUURPDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SNNUURPDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SNNUURPDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SNNUURPDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SNNUURPDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SNNUURPDB] SET  MULTI_USER 
GO
ALTER DATABASE [SNNUURPDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SNNUURPDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SNNUURPDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SNNUURPDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SNNUURPDB]
GO
/****** Object:  StoredProcedure [dbo].[Assignment_ADD]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2015-6-25 上午 1:56:26
------------------------------------
CREATE PROCEDURE [dbo].[Assignment_ADD]
@AssignId int output,
@Tid int,
@Cid int,
@ReleaseTime datetime,
@Deadline datetime,
@AssignDetail text,
@Accessory int

 AS 
	INSERT INTO [Assignment](
	[Tid],[Cid],[ReleaseTime],[Deadline],[AssignDetail],[Accessory]
	)VALUES(
	@Tid,@Cid,@ReleaseTime,@Deadline,@AssignDetail,@Accessory
	)
	SET @AssignId = @@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[Course_ADD]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2015-6-25 上午 1:56:27
------------------------------------
CREATE PROCEDURE [dbo].[Course_ADD]
@Cid int,
@Cname nvarchar(30),
@CnameEnglish varchar(45),
@DeptId int,
@Years date,
@Semaster int,
@CourseAttribute varchar(45),
@CourseCategory int,
@Credit float,
@TextBook nvarchar(50),
@Hours int,
@WeekHours int

 AS 
	INSERT INTO [Course](
	[Cid],[Cname],[CnameEnglish],[DeptId],[Years],[Semaster],[CourseAttribute],[CourseCategory],[Credit],[TextBook],[Hours],[WeekHours]
	)VALUES(
	@Cid,@Cname,@CnameEnglish,@DeptId,@Years,@Semaster,@CourseAttribute,@CourseCategory,@Credit,@TextBook,@Hours,@WeekHours
	)

GO
/****** Object:  StoredProcedure [dbo].[CourseSelect_ADD]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：增加一条记录 
--项目名称：
--说明：
--时间：2015-6-25 上午 1:56:27
------------------------------------
CREATE PROCEDURE [dbo].[CourseSelect_ADD]
@Sid int,
@Cid int,
@Cno int,
@SelectStatus varchar(45)

 AS 
begin

declare @courseReminder int

begin transaction
	update Teach set teach.CourseRemainder=Teach.CourseRemainder-1;
	if(@@ERROR>0)
	rollback
	else
	INSERT INTO [CourseSelect](
	[Sid],[Cid],[Cno],[SelectStatus])VALUES(
	@Sid,@Cid,@Cno,@SelectStatus
	);
commit transaction
end

GO
/****** Object:  StoredProcedure [dbo].[CourseSelect_Delete]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：删除一条记录 
--项目名称：
--说明：
--时间：2015-6-25 上午 1:56:27
------------------------------------
CREATE PROCEDURE [dbo].[CourseSelect_Delete]
@Sid int,
@Cid int,
@Cno int
 AS 
	DELETE [CourseSelect]
	 WHERE Sid=@Sid and Cid=@Cid and Cno=@Cno 
	 update teach set Teach.CourseRemainder=Teach.CourseRemainder+1

GO
/****** Object:  StoredProcedure [dbo].[CourseSelect_Exists]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：是否已经存在 
--项目名称：
--说明：
--时间：2015-6-25 上午 1:56:27
------------------------------------
CREATE PROCEDURE [dbo].[CourseSelect_Exists]
@Sid int,
@Cid int,
@Cno int
AS
	DECLARE @TempID int
	SELECT @TempID = count(1) FROM [CourseSelect] WHERE Sid=@Sid and Cid=@Cid and Cno=@Cno 
	IF @TempID = 0
		RETURN 0
	ELSE
		RETURN 1


GO
/****** Object:  StoredProcedure [dbo].[CourseSelect_GetPage]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：查询记录信息 
--项目名称：
--说明：
--时间：2015-6-25 上午 1:56:27
------------------------------------
CREATE PROCEDURE [dbo].[CourseSelect_GetPage](
@Sid int,
@page_index int=1,
@page_size int=10)
 AS 
 declare @stuId int ,@startRow int,@endRow int
 set @stuId=@Sid
 set @startRow=(@page_index-1)*@page_size+1
 set @endRow=@startRow+@page_size-1
	SELECT
	temp.rowid,temp.Sid,temp.Cid,temp.Cno,temp.SelectStatus,temp.UsualScore,temp.MidtermScore,temp.FinalExamScore,temp.TotalScore
	 FROM (
	 select ROW_NUMBER() over (order by CourseSelect.Cid asc) as rowid,* from CourseSelect where CourseSelect.Sid=@stuId) temp
	 where rowid between @startRow and @endRow


GO
/****** Object:  StoredProcedure [dbo].[TotalScore_Update]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：更新一条成绩记录 
--项目名称：
--说明：
--时间：2015-6-25 上午 1:56:27
------------------------------------
CREATE PROCEDURE [dbo].[TotalScore_Update]
@Sid int,
@Cid int,
@Cno int,
@TotalScore int
 AS 
	UPDATE [CourseSelect] SET 
	[TotalScore] = @TotalScore
	WHERE Sid=@Sid and Cid=@Cid and Cno=@Cno
GO
/****** Object:  Table [dbo].[Assignment]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignment](
	[AssignId] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Cid] [int] NOT NULL,
	[ReleaseTime] [datetime] NULL,
	[Deadline] [datetime] NULL,
	[AssignDetail] [text] NULL,
	[Accessory] [int] NULL,
 CONSTRAINT [PK__Assignme__9FFF4CAF93CD8A42] PRIMARY KEY CLUSTERED 
(
	[AssignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssignmentSubmit]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AssignmentSubmit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sid] [int] NOT NULL,
	[AssignmentId] [int] NOT NULL,
	[Detail] [varchar](45) NULL,
	[Accessory] [int] NULL,
 CONSTRAINT [PK__Assignme__0FFB3272787F9319] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Class]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Class](
	[ClassId] [int] NOT NULL,
	[ClassName] [nvarchar](45) NULL,
	[MajorId] [int] NULL,
	[Grade] [varchar](45) NULL,
	[StuCount] [int] NULL,
	[DistrictId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ClassRoom]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClassRoom](
	[Rid] [int] NOT NULL,
	[Rname] [nvarchar](20) NULL,
	[BuildId] [int] NULL,
	[RoomType] [varchar](45) NULL,
	[Capacity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Cid] [int] NOT NULL,
	[Cname] [nvarchar](30) NULL,
	[CnameEnglish] [varchar](45) NULL,
	[DeptId] [int] NULL,
	[Years] [date] NULL,
	[Semaster] [int] NULL,
	[CourseAttribute] [varchar](45) NULL,
	[CourseCategory] [int] NULL,
	[Credit] [float] NULL,
	[TextBook] [nvarchar](50) NULL,
	[Hours] [int] NULL,
	[WeekHours] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseCategory]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseCategory](
	[CouseCateId] [int] NOT NULL,
	[Category] [nvarchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[CouseCateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CourseSelect]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CourseSelect](
	[Sid] [int] NOT NULL,
	[Cid] [int] NOT NULL,
	[Cno] [int] NOT NULL,
	[SelectStatus] [varchar](45) NULL,
	[UsualScore] [int] NULL,
	[MidtermScore] [int] NULL,
	[FinalExamScore] [int] NULL,
	[TotalScore] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sid] ASC,
	[Cid] ASC,
	[Cno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Depart]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Depart](
	[DeptId] [int] NOT NULL,
	[DeptName] [nvarchar](30) NULL,
	[MasterName] [nvarchar](45) NULL,
	[DistrictId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FileInfo]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileInfo](
	[Guid] [int] NOT NULL,
	[FileName] [varchar](45) NULL,
	[FileExtension] [varchar](45) NULL,
	[Uploader] [int] NULL,
	[DownloadCount] [int] NULL,
	[Comment] [varchar](45) NULL,
	[IsAssignmentFile] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Major]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Major](
	[MajorId] [int] NOT NULL,
	[MajorName] [nvarchar](30) NULL,
	[DeptId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MajorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlanDetail]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanDetail](
	[PlanId] [int] NOT NULL,
	[Cid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PlanId] ASC,
	[Cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoomUse]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoomUse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Rid] [int] NOT NULL,
	[Uid] [int] NOT NULL,
	[UseDate] [datetime] NULL,
	[Purpose] [nvarchar](50) NULL,
	[UseStatus] [varchar](45) NULL,
 CONSTRAINT [PK__RoomUse__3214EC070909D326] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SchoolDistrict]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolDistrict](
	[DistrictId] [int] IDENTITY(1,1) NOT NULL,
	[DistrictName] [nvarchar](30) NULL,
	[Address] [nvarchar](50) NULL,
 CONSTRAINT [PK__SchoolDi__85FDA4C606A79CA6] PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StuInfo]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StuInfo](
	[Sid] [int] NOT NULL,
	[Sname] [nvarchar](30) NULL,
	[SnameSpell] [varchar](45) NULL,
	[SnameEnglish] [varchar](45) NULL,
	[SnameOld] [nvarchar](45) NULL,
	[IdNumber] [varchar](45) NULL,
	[Sex] [bit] NULL,
	[StuType] [nvarchar](45) NULL,
	[StuNationality] [nvarchar](20) NULL,
	[StuProvince] [nvarchar](45) NULL,
	[StuBirthday] [date] NULL,
	[StuPolitical] [nvarchar](45) NULL,
	[StuDept] [int] NULL,
	[StuZipCode] [varchar](45) NULL,
	[StuEnrollDate] [date] NULL,
	[StuMajor] [int] NULL,
	[StuGrade] [int] NULL,
	[StuClassId] [int] NULL,
	[PlanId] [int] NULL,
	[District] [nvarchar](45) NULL,
PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teach]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teach](
	[Cid] [int] NOT NULL,
	[Cno] [int] NOT NULL,
	[Tid] [int] NOT NULL,
	[CourseRemainder] [int] NULL,
	[Period] [nvarchar](45) NULL,
	[Week] [varchar](45) NULL,
	[Section] [int] NULL,
	[SectionCount] [int] NULL,
	[DistrictId] [int] NULL,
	[BuildId] [int] NULL,
	[ClassRoomId] [int] NULL,
 CONSTRAINT [PK__Teach__55B055F3845B4578] PRIMARY KEY CLUSTERED 
(
	[Cid] ASC,
	[Cno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeachBuilding]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeachBuilding](
	[BuildId] [int] IDENTITY(1,1) NOT NULL,
	[BuildName] [nvarchar](20) NULL,
	[DistrictId] [int] NULL,
 CONSTRAINT [PK__TeachBui__C51051418CCB9A52] PRIMARY KEY CLUSTERED 
(
	[BuildId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Tid] [int] NOT NULL,
	[Tname] [nvarchar](30) NULL,
	[Sex] [bit] NULL,
	[IdNumber] [varchar](45) NULL,
	[DeptId] [int] NULL,
	[TeacherTypeId] [int] NULL,
	[Degree] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Tid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeacherType]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherType](
	[TeaTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherTypes] [nvarchar](20) NULL,
	[HoursSalary] [decimal](18, 0) NULL,
 CONSTRAINT [PK__TeacherT__17978B153A0C61F5] PRIMARY KEY CLUSTERED 
(
	[TeaTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrainPlan]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TrainPlan](
	[PlanId] [int] IDENTITY(1,1) NOT NULL,
	[PlanName] [nvarchar](45) NULL,
	[Grade] [varchar](45) NULL,
	[MajorId] [int] NULL,
	[CourseCount] [int] NULL,
	[CourseCredit] [float] NULL,
	[CourseHours] [float] NULL,
	[Remark] [nvarchar](100) NULL,
 CONSTRAINT [PK__TrainPla__755C22B77EEAF4AE] PRIMARY KEY CLUSTERED 
(
	[PlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Uid] [int] NOT NULL,
	[Uname] [nvarchar](45) NULL,
	[Pwd] [varchar](45) NULL,
	[UserType] [int] NULL,
	[UserPhone] [varchar](45) NULL,
	[UserEmail] [varchar](45) NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserPower]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPower](
	[UserType] [int] NOT NULL,
	[UserPower1] [nvarchar](50) NULL,
	[UserPower2] [nvarchar](50) NULL,
 CONSTRAINT [PK__UserPowe__87E786906904E9A6] PRIMARY KEY CLUSTERED 
(
	[UserType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WageAdjustment]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WageAdjustment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[NewSalary] [decimal](18, 0) NULL,
	[OldSalary] [decimal](18, 0) NULL,
	[Reason] [nvarchar](45) NULL,
	[AdjustDate] [date] NULL,
	[Remark] [nvarchar](200) NULL,
 CONSTRAINT [PK__WageAdju__3214EC0792DD45A9] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WageInfo]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WageInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tid] [int] NOT NULL,
	[Tname] [nvarchar](20) NULL,
	[Month] [varchar](45) NULL,
	[BasicWage] [decimal](18, 0) NULL,
	[JobSubsidies] [decimal](18, 0) NULL,
	[PersonalIncomeTax] [varchar](45) NULL,
	[SocialSecurity] [varchar](45) NULL,
	[Remark] [nvarchar](200) NULL,
 CONSTRAINT [PK__WageInfo__3214EC070CB9DEE0] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[RoomUseView]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RoomUseView]
AS
SELECT   dbo.RoomUse.Id, dbo.UserInfo.Uid, dbo.UserInfo.Uname, dbo.UserInfo.UserPhone, dbo.ClassRoom.Rname, 
                dbo.ClassRoom.RoomType, dbo.ClassRoom.Capacity, dbo.RoomUse.Purpose, dbo.RoomUse.UseDate, 
                dbo.RoomUse.UseStatus, dbo.RoomUse.Rid, dbo.UserInfo.UserEmail
FROM      dbo.ClassRoom INNER JOIN
                dbo.RoomUse ON dbo.ClassRoom.Rid = dbo.RoomUse.Rid INNER JOIN
                dbo.UserInfo ON dbo.RoomUse.Uid = dbo.UserInfo.Uid

GO
/****** Object:  View [dbo].[SelectedStudentView]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SelectedStudentView]
AS
SELECT   dbo.Teach.Tid, dbo.StuInfo.Sid, dbo.StuInfo.Sname, dbo.StuInfo.Sex, dbo.Major.MajorName, dbo.Depart.DeptName, 
                dbo.Course.Years, dbo.Course.Semaster
FROM      dbo.Class INNER JOIN
                dbo.Major ON dbo.Class.MajorId = dbo.Major.MajorId INNER JOIN
                dbo.Depart ON dbo.Major.DeptId = dbo.Depart.DeptId INNER JOIN
                dbo.StuInfo ON dbo.Class.ClassId = dbo.StuInfo.StuClassId AND dbo.Major.MajorId = dbo.StuInfo.StuMajor INNER JOIN
                dbo.CourseSelect ON dbo.StuInfo.Sid = dbo.CourseSelect.Sid INNER JOIN
                dbo.Teach ON dbo.CourseSelect.Cid = dbo.Teach.Cid AND dbo.CourseSelect.Cno = dbo.Teach.Cno INNER JOIN
                dbo.Course ON dbo.Depart.DeptId = dbo.Course.DeptId AND dbo.Teach.Cid = dbo.Course.Cid

GO
/****** Object:  View [dbo].[TeachCourseView]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TeachCourseView]
AS
SELECT   dbo.Teacher.Tid, dbo.Teacher.Tname, dbo.Course.Cid, dbo.Course.Cname, dbo.Course.DeptId, dbo.Course.Years, 
                dbo.Course.Semaster, dbo.Course.CourseAttribute, dbo.Course.Credit, dbo.Course.TextBook, dbo.Course.Hours, 
                dbo.Course.WeekHours, dbo.Teach.CourseRemainder, dbo.Teach.Section, dbo.Teach.Week
FROM      dbo.Teach INNER JOIN
                dbo.Teacher ON dbo.Teach.Tid = dbo.Teacher.Tid INNER JOIN
                dbo.Course ON dbo.Teach.Cid = dbo.Course.Cid

GO
/****** Object:  View [dbo].[TeacherScoreView]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TeacherScoreView]
AS
SELECT   dbo.CourseSelect.Sid, dbo.Teach.Tid, dbo.Course.Cname, dbo.StuInfo.Sname, dbo.Course.Years, dbo.Course.Semaster, 
                dbo.CourseSelect.UsualScore, dbo.CourseSelect.MidtermScore, dbo.CourseSelect.FinalExamScore, 
                dbo.CourseSelect.TotalScore
FROM      dbo.CourseSelect INNER JOIN
                dbo.StuInfo ON dbo.CourseSelect.Sid = dbo.StuInfo.Sid INNER JOIN
                dbo.Teach ON dbo.CourseSelect.Cid = dbo.Teach.Cid AND dbo.CourseSelect.Cno = dbo.Teach.Cno INNER JOIN
                dbo.Course ON dbo.Course.Cid = dbo.Teach.Cid

GO
/****** Object:  View [dbo].[TeacherWageAdjustmentView]    Script Date: 2015-7-9 上午 12:22:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create view [dbo].[TeacherWageAdjustmentView]
as
SELECT   dbo.WageAdjustment.Id, dbo.Teacher.Tid, dbo.Teacher.Tname, dbo.Teacher.Sex, dbo.Teacher.IdNumber, 
                dbo.Teacher.TeacherTypeId, dbo.Teacher.Degree, dbo.Depart.DeptName,dbo.WageAdjustment.NewSalary, dbo.WageAdjustment.OldSalary, dbo.WageInfo.BasicWage, 
                dbo.WageInfo.JobSubsidies, dbo.WageInfo.PersonalIncomeTax
FROM     
                dbo.Teacher INNER JOIN
                dbo.WageAdjustment ON dbo.Teacher.Tid = dbo.WageAdjustment.Tid INNER JOIN
                dbo.WageInfo ON dbo.Teacher.Tid = dbo.WageInfo.Tid INNER JOIN
                dbo.Depart ON dbo.Teacher.DeptId = dbo.Depart.DeptId
GO
/****** Object:  Index [fk_AccessoryFileId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_AccessoryFileId_idx] ON [dbo].[Assignment]
(
	[Accessory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [TeaId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [TeaId_idx] ON [dbo].[Assignment]
(
	[Tid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_AccessoryFileId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_AccessoryFileId_idx] ON [dbo].[AssignmentSubmit]
(
	[Accessory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_AssignmentId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_AssignmentId_idx] ON [dbo].[AssignmentSubmit]
(
	[AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_MajorId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_MajorId_idx] ON [dbo].[Class]
(
	[MajorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_SchoolDistrict_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_SchoolDistrict_idx] ON [dbo].[Class]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [BuildId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [BuildId_idx] ON [dbo].[ClassRoom]
(
	[BuildId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_CourseCategoryId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_CourseCategoryId_idx] ON [dbo].[Course]
(
	[CourseCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_DeptId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_DeptId_idx] ON [dbo].[Course]
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_SchoolDistrictId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_SchoolDistrictId_idx] ON [dbo].[Depart]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [DeptId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [DeptId_idx] ON [dbo].[Major]
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_CourseId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_CourseId_idx] ON [dbo].[PlanDetail]
(
	[Cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_ClassRoomId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_ClassRoomId_idx] ON [dbo].[RoomUse]
(
	[Rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_ClassId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_ClassId_idx] ON [dbo].[StuInfo]
(
	[StuClassId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_PlanId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_PlanId_idx] ON [dbo].[StuInfo]
(
	[PlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_StudentMajorId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_StudentMajorId_idx] ON [dbo].[StuInfo]
(
	[StuMajor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_ClassRoomId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_ClassRoomId_idx] ON [dbo].[Teach]
(
	[ClassRoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_TeacherId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_TeacherId_idx] ON [dbo].[Teach]
(
	[Tid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [CampusId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [CampusId_idx] ON [dbo].[TeachBuilding]
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [FK_Teacher_DepartId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [FK_Teacher_DepartId_idx] ON [dbo].[Teacher]
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [FK_Teacher_TypeId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [FK_Teacher_TypeId_idx] ON [dbo].[Teacher]
(
	[TeacherTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [MajorId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [MajorId_idx] ON [dbo].[TrainPlan]
(
	[MajorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_TeacherId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_TeacherId_idx] ON [dbo].[WageAdjustment]
(
	[Tid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [fk_TeacherId_idx]    Script Date: 2015-7-9 上午 12:22:36 ******/
CREATE NONCLUSTERED INDEX [fk_TeacherId_idx] ON [dbo].[WageInfo]
(
	[Tid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [fk_AccessoryFileId] FOREIGN KEY([Accessory])
REFERENCES [dbo].[FileInfo] ([Guid])
GO
ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [fk_AccessoryFileId]
GO
ALTER TABLE [dbo].[Assignment]  WITH CHECK ADD  CONSTRAINT [fk_Teacher_Assignment] FOREIGN KEY([Tid])
REFERENCES [dbo].[Teacher] ([Tid])
GO
ALTER TABLE [dbo].[Assignment] CHECK CONSTRAINT [fk_Teacher_Assignment]
GO
ALTER TABLE [dbo].[AssignmentSubmit]  WITH CHECK ADD  CONSTRAINT [fk_AssignmentId] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[Assignment] ([AssignId])
GO
ALTER TABLE [dbo].[AssignmentSubmit] CHECK CONSTRAINT [fk_AssignmentId]
GO
ALTER TABLE [dbo].[AssignmentSubmit]  WITH CHECK ADD  CONSTRAINT [fk_AssignmentSubmit_AccessoryFileId] FOREIGN KEY([Accessory])
REFERENCES [dbo].[FileInfo] ([Guid])
GO
ALTER TABLE [dbo].[AssignmentSubmit] CHECK CONSTRAINT [fk_AssignmentSubmit_AccessoryFileId]
GO
ALTER TABLE [dbo].[AssignmentSubmit]  WITH CHECK ADD  CONSTRAINT [fk_StuId] FOREIGN KEY([Sid])
REFERENCES [dbo].[StuInfo] ([Sid])
GO
ALTER TABLE [dbo].[AssignmentSubmit] CHECK CONSTRAINT [fk_StuId]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [fk_MajorId] FOREIGN KEY([MajorId])
REFERENCES [dbo].[Major] ([MajorId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [fk_MajorId]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [fk_SchoolDistrict] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[SchoolDistrict] ([DistrictId])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [fk_SchoolDistrict]
GO
ALTER TABLE [dbo].[ClassRoom]  WITH CHECK ADD  CONSTRAINT [BuildId] FOREIGN KEY([BuildId])
REFERENCES [dbo].[TeachBuilding] ([BuildId])
GO
ALTER TABLE [dbo].[ClassRoom] CHECK CONSTRAINT [BuildId]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [fk_CourseCategoryId] FOREIGN KEY([CourseCategory])
REFERENCES [dbo].[CourseCategory] ([CouseCateId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [fk_CourseCategoryId]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [fk_DeptId] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Depart] ([DeptId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [fk_DeptId]
GO
ALTER TABLE [dbo].[CourseSelect]  WITH CHECK ADD  CONSTRAINT [FK_CourseSelect_StuInfo] FOREIGN KEY([Sid])
REFERENCES [dbo].[StuInfo] ([Sid])
GO
ALTER TABLE [dbo].[CourseSelect] CHECK CONSTRAINT [FK_CourseSelect_StuInfo]
GO
ALTER TABLE [dbo].[CourseSelect]  WITH CHECK ADD  CONSTRAINT [FK_CourseSelect_Teach] FOREIGN KEY([Cid], [Cno])
REFERENCES [dbo].[Teach] ([Cid], [Cno])
GO
ALTER TABLE [dbo].[CourseSelect] CHECK CONSTRAINT [FK_CourseSelect_Teach]
GO
ALTER TABLE [dbo].[Depart]  WITH CHECK ADD  CONSTRAINT [fk_SchoolDistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[SchoolDistrict] ([DistrictId])
GO
ALTER TABLE [dbo].[Depart] CHECK CONSTRAINT [fk_SchoolDistrictId]
GO
ALTER TABLE [dbo].[Major]  WITH CHECK ADD  CONSTRAINT [DeptId] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Depart] ([DeptId])
GO
ALTER TABLE [dbo].[Major] CHECK CONSTRAINT [DeptId]
GO
ALTER TABLE [dbo].[PlanDetail]  WITH CHECK ADD  CONSTRAINT [fk_CourseId] FOREIGN KEY([Cid])
REFERENCES [dbo].[Course] ([Cid])
GO
ALTER TABLE [dbo].[PlanDetail] CHECK CONSTRAINT [fk_CourseId]
GO
ALTER TABLE [dbo].[PlanDetail]  WITH CHECK ADD  CONSTRAINT [fk_TrainPlanId] FOREIGN KEY([PlanId])
REFERENCES [dbo].[TrainPlan] ([PlanId])
GO
ALTER TABLE [dbo].[PlanDetail] CHECK CONSTRAINT [fk_TrainPlanId]
GO
ALTER TABLE [dbo].[RoomUse]  WITH CHECK ADD  CONSTRAINT [fk_ClassRoomId] FOREIGN KEY([Rid])
REFERENCES [dbo].[ClassRoom] ([Rid])
GO
ALTER TABLE [dbo].[RoomUse] CHECK CONSTRAINT [fk_ClassRoomId]
GO
ALTER TABLE [dbo].[RoomUse]  WITH CHECK ADD  CONSTRAINT [FK_RoomUse_UserInfo] FOREIGN KEY([Uid])
REFERENCES [dbo].[UserInfo] ([Uid])
GO
ALTER TABLE [dbo].[RoomUse] CHECK CONSTRAINT [FK_RoomUse_UserInfo]
GO
ALTER TABLE [dbo].[StuInfo]  WITH CHECK ADD  CONSTRAINT [fk_ClassId] FOREIGN KEY([StuClassId])
REFERENCES [dbo].[Class] ([ClassId])
GO
ALTER TABLE [dbo].[StuInfo] CHECK CONSTRAINT [fk_ClassId]
GO
ALTER TABLE [dbo].[StuInfo]  WITH CHECK ADD  CONSTRAINT [fk_PlanId] FOREIGN KEY([PlanId])
REFERENCES [dbo].[TrainPlan] ([PlanId])
GO
ALTER TABLE [dbo].[StuInfo] CHECK CONSTRAINT [fk_PlanId]
GO
ALTER TABLE [dbo].[StuInfo]  WITH CHECK ADD  CONSTRAINT [fk_StudentMajorId] FOREIGN KEY([StuMajor])
REFERENCES [dbo].[Major] ([MajorId])
GO
ALTER TABLE [dbo].[StuInfo] CHECK CONSTRAINT [fk_StudentMajorId]
GO
ALTER TABLE [dbo].[Teach]  WITH CHECK ADD  CONSTRAINT [fk_Teach_ClassRoomId] FOREIGN KEY([ClassRoomId])
REFERENCES [dbo].[ClassRoom] ([Rid])
GO
ALTER TABLE [dbo].[Teach] CHECK CONSTRAINT [fk_Teach_ClassRoomId]
GO
ALTER TABLE [dbo].[Teach]  WITH CHECK ADD  CONSTRAINT [fk_Teach_CourseId] FOREIGN KEY([Cid])
REFERENCES [dbo].[Course] ([Cid])
GO
ALTER TABLE [dbo].[Teach] CHECK CONSTRAINT [fk_Teach_CourseId]
GO
ALTER TABLE [dbo].[Teach]  WITH CHECK ADD  CONSTRAINT [fk_Teach_TeacherId] FOREIGN KEY([Tid])
REFERENCES [dbo].[Teacher] ([Tid])
GO
ALTER TABLE [dbo].[Teach] CHECK CONSTRAINT [fk_Teach_TeacherId]
GO
ALTER TABLE [dbo].[TeachBuilding]  WITH CHECK ADD  CONSTRAINT [fk_DistrictId] FOREIGN KEY([DistrictId])
REFERENCES [dbo].[SchoolDistrict] ([DistrictId])
GO
ALTER TABLE [dbo].[TeachBuilding] CHECK CONSTRAINT [fk_DistrictId]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Depart] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Depart] ([DeptId])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Depart]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [fk_Teacher_TeacherType] FOREIGN KEY([TeacherTypeId])
REFERENCES [dbo].[TeacherType] ([TeaTypeId])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [fk_Teacher_TeacherType]
GO
ALTER TABLE [dbo].[TrainPlan]  WITH CHECK ADD  CONSTRAINT [MajorId] FOREIGN KEY([MajorId])
REFERENCES [dbo].[Major] ([MajorId])
GO
ALTER TABLE [dbo].[TrainPlan] CHECK CONSTRAINT [MajorId]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_UserType] FOREIGN KEY([UserType])
REFERENCES [dbo].[UserPower] ([UserType])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_UserType]
GO
ALTER TABLE [dbo].[WageAdjustment]  WITH CHECK ADD  CONSTRAINT [fk_WageAdjustment_TeacherId] FOREIGN KEY([Tid])
REFERENCES [dbo].[Teacher] ([Tid])
GO
ALTER TABLE [dbo].[WageAdjustment] CHECK CONSTRAINT [fk_WageAdjustment_TeacherId]
GO
ALTER TABLE [dbo].[WageInfo]  WITH CHECK ADD  CONSTRAINT [fk_Teacher_WageInfo] FOREIGN KEY([Tid])
REFERENCES [dbo].[Teacher] ([Tid])
GO
ALTER TABLE [dbo].[WageInfo] CHECK CONSTRAINT [fk_Teacher_WageInfo]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ClassRoom"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RoomUse"
            Begin Extent = 
               Top = 6
               Left = 228
               Bottom = 146
               Right = 374
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserInfo"
            Begin Extent = 
               Top = 150
               Left = 38
               Bottom = 290
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RoomUseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'RoomUseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Teach"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 231
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Teacher"
            Begin Extent = 
               Top = 6
               Left = 269
               Bottom = 146
               Right = 444
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 150
               Left = 38
               Bottom = 290
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeachCourseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeachCourseView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CourseSelect"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 217
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StuInfo"
            Begin Extent = 
               Top = 6
               Left = 407
               Bottom = 146
               Right = 576
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Teach"
            Begin Extent = 
               Top = 167
               Left = 374
               Bottom = 307
               Right = 567
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Course"
            Begin Extent = 
               Top = 6
               Left = 614
               Bottom = 146
               Right = 797
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeacherScoreView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeacherScoreView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TeacherScoreView'
GO
USE [master]
GO
ALTER DATABASE [SNNUURPDB] SET  READ_WRITE 
GO
