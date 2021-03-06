﻿USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudOSB10gCab]    Script Date: 03/29/2016 19:20:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudOSB10gCab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[CodigoProyecto] [varchar](50) NOT NULL,
	[Ambiente] [varchar](50) NOT NULL,
	[ServidorDestino] [varchar](50) NOT NULL,
	[Observaciones] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SolicitudOSB10gCab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudOSB10gCab]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudOSB10gCab_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudOSB10gCab] CHECK CONSTRAINT [FK_SolicitudOSB10gCab_Solicitud]
GO

