USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudConfigApp11gCertificado]    Script Date: 01/12/2016 12:15:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudConfigApp11gCertificado](
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
 CONSTRAINT [PK_SolicitudConfigApp11gCertificado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gCertificado]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudConfigApp11gCertificado_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gCertificado] CHECK CONSTRAINT [FK_SolicitudConfigApp11gCertificado_Solicitud]
GO

