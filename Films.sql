USE [ispp2106]
GO

/****** Object:  Table [dbo].[Films]    Script Date: 23.09.2025 11:04:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Films](
	[FilmId] [int] IDENTITY(1,1) NOT NULL,
	[FilmName] [nchar](30) NOT NULL,
	[GenreId] [int] NULL,
	[AgeRating] [nchar](3) NULL,
	[Rating] [decimal](3, 1) NULL,
 CONSTRAINT [PK_Films] PRIMARY KEY CLUSTERED 
(
	[FilmId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Films]  WITH CHECK ADD  CONSTRAINT [FK_Films_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([GenreId])
GO

ALTER TABLE [dbo].[Films] CHECK CONSTRAINT [FK_Films_Genres]
GO

