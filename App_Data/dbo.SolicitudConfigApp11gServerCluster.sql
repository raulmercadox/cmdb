USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudConfigApp11gServerCluster]    Script Date: 01/12/2016 11:55:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudConfigApp11gServerCluster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](100) NOT NULL,
	[AnalistaDesarrollo] [varchar](100) NOT NULL,
	[Accion] [varchar](100) NOT NULL,
	[ServerCluster] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Destino] [varchar](100) NOT NULL,
	[Parametros] [varchar](100) NOT NULL,
	[Valor] [varchar](100) NOT NULL,
	[Detalles] [varchar](100) NOT NULL,
	[Puerto] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SolicitudConfigApp11gServerCluster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gServerCluster]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudConfigApp11gServerCluster_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gServerCluster] CHECK CONSTRAINT [FK_SolicitudConfigApp11gServerCluster_Solicitud]
GO

