USE [master]
GO
/****** Object:  Database [tyajz]    Script Date: 2012/9/2 23:07:00 ******/
CREATE DATABASE [tyajz]

ALTER DATABASE [tyajz] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tyajz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tyajz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [tyajz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [tyajz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [tyajz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [tyajz] SET ARITHABORT OFF 
GO
ALTER DATABASE [tyajz] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [tyajz] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [tyajz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [tyajz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [tyajz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [tyajz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [tyajz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [tyajz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [tyajz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [tyajz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [tyajz] SET  DISABLE_BROKER 
GO
ALTER DATABASE [tyajz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [tyajz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [tyajz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [tyajz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [tyajz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [tyajz] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [tyajz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [tyajz] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [tyajz] SET  MULTI_USER 
GO
ALTER DATABASE [tyajz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [tyajz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [tyajz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [tyajz] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [tyajz]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2012/9/2 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SystemVariable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Company]    Script Date: 2012/9/2 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Legal] [nvarchar](10) NOT NULL,
	[PhoneOfLegal] [nvarchar](20) NOT NULL,
	[Contactor] [nvarchar](10) NOT NULL,
	[ContactorPhone] [nvarchar](20) NOT NULL,
	[CanProduct] [bit] NOT NULL,
	[ProductCertNO] [nvarchar](100) NOT NULL,
	[CanInstall] [bit] NOT NULL,
	[InstallCertNO] [nvarchar](100) NOT NULL,
	[CanLend] [bit] NOT NULL,
	[LendCertNO] [nvarchar](100) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[CreateDT] [datetime] NOT NULL,
	[ModifiedDT] [datetime] NOT NULL,
	[LastModifiedUser] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Constructor]    Script Date: 2012/9/2 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Constructor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Employer] [nvarchar](100) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CertificationNO] [nvarchar](100) NOT NULL,
	[IssuingAuthority] [nvarchar](100) NOT NULL,
	[Gender] [int] NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[BirthYear] [int] NOT NULL,
	[InsuranceId] [int] NOT NULL,
	[Comment] [nvarchar](100) NOT NULL,
	[IsPrinted] [bit] NOT NULL,
	[CreateDT] [datetime] NOT NULL,
	[ModifiedDT] [datetime] NOT NULL,
	[LastModifiedUser] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Constructor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Driver]    Script Date: 2012/9/2 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Driver](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NO] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CertificationNO] [nvarchar](100) NOT NULL,
	[Employer] [nvarchar](50) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Gender] [int] NOT NULL,
	[BirthYear] [int] NOT NULL,
	[IssuingAuthority] [nvarchar](50) NOT NULL,
	[IssueDate] [datetime] NOT NULL,
	[IsInsurance] [bit] NOT NULL,
	[IsWorking] [bit] NOT NULL,
	[CreateDT] [datetime] NOT NULL,
	[ModifiedDT] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsPrinted] [bit] NOT NULL,
	[LastModifiedUser] [int] NOT NULL,
	[Comment] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Driver] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Insurance]    Script Date: 2012/9/2 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insurance](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Insurance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 2012/9/2 23:07:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PassWord] [nvarchar](50) NOT NULL,
	[RealName] [nvarchar](50) NOT NULL,
	[UserType] [nvarchar](50) NOT NULL,
	[CreateDT] [datetime] NOT NULL,
	[ModifiedDT] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Company]  WITH CHECK ADD  CONSTRAINT [FK_Company_User] FOREIGN KEY([LastModifiedUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Company] CHECK CONSTRAINT [FK_Company_User]
GO
ALTER TABLE [dbo].[Constructor]  WITH CHECK ADD  CONSTRAINT [FK_Constructor_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Constructor] CHECK CONSTRAINT [FK_Constructor_Category]
GO
ALTER TABLE [dbo].[Constructor]  WITH CHECK ADD  CONSTRAINT [FK_Constructor_Insurance] FOREIGN KEY([InsuranceId])
REFERENCES [dbo].[Insurance] ([Id])
GO
ALTER TABLE [dbo].[Constructor] CHECK CONSTRAINT [FK_Constructor_Insurance]
GO
ALTER TABLE [dbo].[Constructor]  WITH CHECK ADD  CONSTRAINT [FK_Constructor_User] FOREIGN KEY([LastModifiedUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Constructor] CHECK CONSTRAINT [FK_Constructor_User]
GO
ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [FK_Driver_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Driver] CHECK CONSTRAINT [FK_Driver_Category]
GO
ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [FK_Driver_User] FOREIGN KEY([LastModifiedUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Driver] CHECK CONSTRAINT [FK_Driver_User]
GO
USE [master]
GO
ALTER DATABASE [tyajz] SET  READ_WRITE 
GO
