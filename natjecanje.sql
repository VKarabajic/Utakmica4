DROP DATABASE IF EXISTS UtakmicaDB
CREATE DATABASE UtakmicaDB

USE [UtakmicaDB]
GO
/****** Object:  Table [dbo].[Natjecanje]    Script Date: 04.02.2019. 11:30:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Natjecanje](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NazivUtakmice] [nvarchar](100) NOT NULL,
	[Ekipa1] [nvarchar](100) NOT NULL,
	[Ekipa2] [nvarchar](100) NOT NULL,
	[Raspored] [datetime] NOT NULL,
	[RezultatE1] [int] NULL,
	[RezultatE2] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
