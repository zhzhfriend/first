USE [tyajz]
GO

/****** Object:  Table [dbo].[UserSession]    Script Date: 2012/9/12 22:16:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserSession](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [int] NOT NULL,
	[LoginDT] [datetime] NOT NULL,
	[LastActivityDT] [datetime] NOT NULL,
	[RemoteIP] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
	[CreateDT] [datetime] NOT NULL,
	[ModifiedDT] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_UserSession] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserSession]  WITH CHECK ADD  CONSTRAINT [FK_UserSession_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[UserSession] CHECK CONSTRAINT [FK_UserSession_User]
GO


