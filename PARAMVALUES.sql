USE [LIMEBASE]
GO

/****** Object:  Table [dbo].[ParamValues]    Script Date: 24.06.2013 18:09:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParamValues](
	[ParamValueId] [int] IDENTITY(1,1) NOT NULL,
	[ParamId] [int] NOT NULL,
	[ParamValueText] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ParamValues] PRIMARY KEY CLUSTERED 
(
	[ParamValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ParamValues]  WITH CHECK ADD  CONSTRAINT [FK_ParamValues_Params] FOREIGN KEY([ParamId])
REFERENCES [dbo].[Params] ([ParamId])
GO

ALTER TABLE [dbo].[ParamValues] CHECK CONSTRAINT [FK_ParamValues_Params]
GO

