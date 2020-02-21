USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudConfigApp11gCarpetaArchivo]    Script Date: 01/12/2016 12:04:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudConfigApp11gCarpetaArchivo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](100) NOT NULL,
	[AnalistaDesarrollo] [varchar](100) NOT NULL,
	[Accion] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[RutaOrigen] [varchar](500) NOT NULL,
	[RutaDestino] [varchar](500) NOT NULL,
	[ServidoresDestino] [varchar](500) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[TieneParametros] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SolicitudConfigApp11gCarpetaArchivo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gCarpetaArchivo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudConfigApp11gCarpetaArchivo_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gCarpetaArchivo] CHECK CONSTRAINT [FK_SolicitudConfigApp11gCarpetaArchivo_Solicitud]
GO

