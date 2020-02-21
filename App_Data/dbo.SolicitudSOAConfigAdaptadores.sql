USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudSOAConfigAdaptadores]    Script Date: 04/05/2016 17:57:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudSOAConfigAdaptadores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[JNDILocation] [varchar](50) NOT NULL,
	[ConnectionFactory] [varchar](50) NOT NULL,
	[ConnectionInterface] [varchar](50) NOT NULL,
	[Atributo] [varchar](50) NOT NULL,
	[OpcionesAdicionales] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudSOAConfigAdaptadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudSOAConfigAdaptadores]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudSOAConfigAdaptadores_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudSOAConfigAdaptadores] CHECK CONSTRAINT [FK_SolicitudSOAConfigAdaptadores_Solicitud]
GO

