USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudOSB11gConfigAdaptadores]    Script Date: 03/31/2016 18:27:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudOSB11gConfigAdaptadores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[JNDI] [varchar](100) NOT NULL,
	[DataSourceName] [varchar](50) NOT NULL,
	[ConnectionInitial] [varchar](50) NOT NULL,
	[ConnectionMaximum] [varchar](50) NOT NULL,
	[ConnectionMinimum] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudOSB11gConfigAdaptadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigAdaptadores]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudOSB11gConfigAdaptadores_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigAdaptadores] CHECK CONSTRAINT [FK_SolicitudOSB11gConfigAdaptadores_Solicitud]
GO

