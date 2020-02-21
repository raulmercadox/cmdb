USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudDiscovererObjetos]    Script Date: 03/23/2016 10:22:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudDiscovererObjetos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[NombreObjeto] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Observacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudDiscovererObjetos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudDiscovererObjetos]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudDiscovererObjetos_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudDiscovererObjetos] CHECK CONSTRAINT [FK_SolicitudDiscovererObjetos_Solicitud]
GO

