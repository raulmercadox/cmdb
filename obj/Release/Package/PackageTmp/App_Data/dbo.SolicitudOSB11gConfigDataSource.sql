USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudOSB11gConfigDataSource]    Script Date: 03/31/2016 18:29:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudOSB11gConfigDataSource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ServerCluster] [varchar](100) NOT NULL,
	[JNDIName] [varchar](50) NOT NULL,
	[URL] [varchar](100) NOT NULL,
	[DriverClassName] [varchar](50) NOT NULL,
	[User] [varchar](50) NOT NULL,
	[CapacityInitial] [varchar](50) NOT NULL,
	[CapacityMaximum] [varchar](50) NOT NULL,
	[CapacityMinimum] [varchar](50) NOT NULL,
	[SupportGlobal] [varchar](50) NOT NULL,
	[StatementCache] [varchar](50) NOT NULL,
	[InactiveConnection] [varchar](50) NOT NULL,
	[TestConnections] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudOSB11gConfigDataSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigDataSource]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudOSB11gConfigDataSource_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigDataSource] CHECK CONSTRAINT [FK_SolicitudOSB11gConfigDataSource_Solicitud]
GO

