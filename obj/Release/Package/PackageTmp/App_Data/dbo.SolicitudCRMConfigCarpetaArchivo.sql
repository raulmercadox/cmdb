USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudCRMConfigCarpetaArchivo]    Script Date: 03/18/2016 18:25:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudCRMConfigCarpetaArchivo](
	[Id] [int] NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](100) NOT NULL,
	[AnalistaDesarrollo] [varchar](100) NOT NULL,
	[Accion] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[RutaOrigen] [varchar](100) NOT NULL,
	[RutaDestino] [varchar](100) NOT NULL,
	[ServidoresDestino] [varchar](500) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[TieneParametros] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SolicitudCRMConfigCarpetaArchivo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudCRMConfigCarpetaArchivo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCRMConfigCarpetaArchivo_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudCRMConfigCarpetaArchivo] CHECK CONSTRAINT [FK_SolicitudCRMConfigCarpetaArchivo_Solicitud]
GO

