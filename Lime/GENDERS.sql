USE [LIMEBASE]
GO

/****** Object:  Table [dbo].[Genders]    Script Date: 07/03/2013 10:26:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Genders](
	[GenderId] [int] IDENTITY(1,1) NOT NULL,
	[GenderName] [nchar](10) NOT NULL,
 CONSTRAINT [PK__Gender] PRIMARY KEY CLUSTERED 
(
	[GenderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

