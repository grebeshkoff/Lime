USE [LIMEBASE]
GO

/****** Object:  Table [dbo].[Logs]    Script Date: 07/03/2013 10:26:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Logs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[LogUser] [nchar](50) NOT NULL,
	[LogIPAddress] [nchar](50) NOT NULL,
	[LogOperation] [nvarchar](50) NOT NULL,
	[LogPerson] [nvarchar](255) NOT NULL,
	[LogLang] [nvarchar](50) NOT NULL,
	[LogTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

