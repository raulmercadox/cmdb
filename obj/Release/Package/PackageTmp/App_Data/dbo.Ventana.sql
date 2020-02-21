﻿USE [cmdb]
GO

/****** Object:  Table [dbo].[Ventana]    Script Date: 11/19/2014 18:00:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Ventana](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Desde] [datetime] NOT NULL,
	[Hasta] [datetime] NOT NULL,
 CONSTRAINT [PK_Ventana] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO