USE [LIMEBASE]
GO

/****** Object:  Table [dbo].[Persons]    Script Date: 07/03/2013 10:27:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[PersonCode] [nvarchar](50) NOT NULL,
	[PersonFullName] [nvarchar](255) NOT NULL,
	[PersonGender] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Genders] FOREIGN KEY([PersonGender])
REFERENCES [dbo].[Genders] ([GenderId])
GO

ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Genders]
GO

