﻿USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudOSB11gConfigCertificados]    Script Date: 03/31/2016 18:28:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudOSB11gConfigCertificados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[RutaOrigen] [varchar](100) NOT NULL,
	[RutaDestino] [varchar](100) NOT NULL,
	[ServidoresDestino] [varchar](100) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SolicitudOSB11gConfigCertificados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigCertificados]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudOSB11gConfigCertificados_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigCertificados] CHECK CONSTRAINT [FK_SolicitudOSB11gConfigCertificados_Solicitud]
GO

