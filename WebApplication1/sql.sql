USE [JobData]
GO

/****** Object:  Table [dbo].[Job]    Script Date: 16-06-2020 00:03:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Job](
	[Id] [uniqueidentifier] NOT NULL,
	[JobTitle] [varchar](50) NULL,
	[ProfileData] [varchar](200) NULL,
	[CompanyInfo] [varchar](max) NULL,
	[JobTask] [varchar](max) NULL,
	[CandidateProfile] [varchar](max) NULL,
	[ApplicationInfo] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Job] ADD  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[Job] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO


