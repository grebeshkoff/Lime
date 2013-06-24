USE [LIMEBASE]
GO

/****** Object:  Table [dbo].[Params]    Script Date: 24.06.2013 18:08:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Params](
	[ParamId] [int] IDENTITY(1,1) NOT NULL,
	[ParamName] [nvarchar](255) NOT NULL,
	[ParamType] [int] NOT NULL,
	[ParamPersonId] [int] NOT NULL,
	[ParamValue] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Params] PRIMARY KEY CLUSTERED 
(
	[ParamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Params]  WITH CHECK ADD  CONSTRAINT [FK_Params_Persons] FOREIGN KEY([ParamPersonId])
REFERENCES [dbo].[Persons] ([PersonId])
GO

ALTER TABLE [dbo].[Params] CHECK CONSTRAINT [FK_Params_Persons]
GO

