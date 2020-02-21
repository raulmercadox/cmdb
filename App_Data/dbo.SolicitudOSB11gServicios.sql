﻿USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudOSB11gServicios]    Script Date: 03/30/2016 18:06:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudOSB11gServicios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[RutaOrigen] [varchar](100) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[NombreJar] [varchar](50) NOT NULL,
	[ProyectoServicio] [varchar](50) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[ParametrosAmbiente] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudOSB11gServicios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudOSB11gServicios]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudOSB11gServicios_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudOSB11gServicios] CHECK CONSTRAINT [FK_SolicitudOSB11gServicios_Solicitud]
GO

