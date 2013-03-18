CREATE TABLE [dbo].[EquipmentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](50) NOT NULL,
	[LimitedMonth] [int] NOT NULL,
 CONSTRAINT [PK_EquipmentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Equipment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Eq_no] [nvarchar](100) NOT NULL,
	[IsLocal] [bit] NOT NULL,
	[Eq_Name] [int] NOT NULL,
	[Eq_Type] [nvarchar](100) NOT NULL,
	[Eq_CertNo] [nvarchar](100) NOT NULL,
	[Eq_MadeDate] [datetime] NOT NULL,
	[Eq_MadeNo] [nvarchar](100) NOT NULL,
	[Eq_Owner] [nvarchar](100) NULL,
	[Eq_InCharge] [nvarchar](100) NULL,
	[Eq_Adderss] [nvarchar](100) NULL,
	[Eq_OwnerId] [int] NULL,
	[Eq_Producer] [nvarchar](100) NULL,
	[Eq_SpecCertNo] [nvarchar](50) NULL,
	[Eq_ProducerId] [int] NULL,
	[Eq_RecDeskNo] [nvarchar](50) NOT NULL,
	[Eq_RecBoxNo] [nvarchar](50) NOT NULL,
	[Eq_Status] [nvarchar](50) NOT NULL,
	[Eq_IsPrinted] [bit] NOT NULL,
	[Eq_Recorder] [int] NOT NULL,
	[Eq_Comment] [nvarchar](max) NOT NULL,
	[CreateDT] [datetime] NOT NULL,
	[ModifiedDT] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_EquipmentType] FOREIGN KEY([Eq_Name])
REFERENCES [dbo].[EquipmentType] ([Id])
GO

ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_EquipmentType]
GO

ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Owner] FOREIGN KEY([Eq_OwnerId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_Owner]
GO

ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_Producer] FOREIGN KEY([Eq_ProducerId])
REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_Producer]
GO

ALTER TABLE [dbo].[Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Equipment_User] FOREIGN KEY([Eq_Recorder])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[Equipment] CHECK CONSTRAINT [FK_Equipment_User]
GO


