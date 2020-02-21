USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudTomcatApp]    Script Date: 01/05/2016 14:22:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudTomcatApp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](100) NOT NULL,
	[AnalistaDesarrollo] [varchar](100) NOT NULL,
	[RutaOrigen] [varchar](500) NOT NULL,
	[RutaDestino] [varchar](500) NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
	[Aplicacion] [varchar](100) NOT NULL,
	[Accion] [varchar](100) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[TieneParametros] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SolicitudTomcatApp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudTomcatApp]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudTomcatApp_SolicitudTomcatApp] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudTomcatApp] CHECK CONSTRAINT [FK_SolicitudTomcatApp_SolicitudTomcatApp]
GO

