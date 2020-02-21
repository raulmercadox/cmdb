USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudOSB11gConfigServerCluster]    Script Date: 03/31/2016 18:30:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudOSB11gConfigServerCluster](
	[Id] [int] NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[ServerCluster] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Servidor] [varchar](50) NOT NULL,
	[Parametro] [varchar](50) NOT NULL,
	[Valor] [varchar](50) NOT NULL,
	[Detalles] [varchar](50) NOT NULL,
	[Puerto] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudOSB11gConfigServerCluster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigServerCluster]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudOSB11gConfigServerCluster_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigServerCluster] CHECK CONSTRAINT [FK_SolicitudOSB11gConfigServerCluster_Solicitud]
GO

