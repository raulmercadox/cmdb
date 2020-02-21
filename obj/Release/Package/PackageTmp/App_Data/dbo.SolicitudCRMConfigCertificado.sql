USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudCRMConfigCertificado]    Script Date: 03/18/2016 18:39:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudCRMConfigCertificado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK_SolicitudCRMConfigCertificado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudCRMConfigCertificado]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCRMConfigCertificado_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudCRMConfigCertificado] CHECK CONSTRAINT [FK_SolicitudCRMConfigCertificado_Solicitud]
GO

