CREATE TABLE [dbo].[Equipment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Eq_no] [nvarchar](100) NOT NULL,
	[IsLocal] [nvarchar](100) NOT NULL,
	[Eq_Name] [nvarchar](100) NOT NULL,
	[Eq_Type] [nvarchar](100) NOT NULL,
	[Eq_CertNo] [nvarchar](100) NOT NULL,
	[Eq_MadeDate] [datetime] NOT NULL,
	[Eq_MadeNo] [int] NOT NULL,
	[Eq_Owner] [nvarchar](100) NOT NULL,
	[Eq_InCharge] [nvarchar](100) NOT NULL,
	[Eq_Adderss] [nvarchar](100) NOT NULL,
	[Eq_Producer] [nvarchar](100) NOT NULL,
	[Eq_SpecCertNo] [int] NOT NULL,
	[Eq_LimitMonths] [datetime] NOT NULL,
	[Eq_HaveUsedMonths] [datetime] NOT NULL,
	[Eq_RecDeskNo] [int] NOT NULL,
	[Eq_RecBoxNo] [int] NOT NULL,
	[Eq_Status] [int] NOT NULL,
	[Eq_IsPrinted] [int] NOT NULL,
	[Eq_Recorder][nvarchar](100) NOT NULL,
	[Eq_Comment] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Equipment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
