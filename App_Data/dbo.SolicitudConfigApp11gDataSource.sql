USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudConfigApp11gDataSource]    Script Date: 01/12/2016 12:00:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudConfigApp11gDataSource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](100) NOT NULL,
	[AnalistaDesarrollo] [varchar](100) NOT NULL,
	[Accion] [varchar](100) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[ServerCluster] [varchar](100) NOT NULL,
	[JndiName] [varchar](100) NOT NULL,
	[Url] [varchar](100) NOT NULL,
	[DriverClassName] [varchar](100) NOT NULL,
	[User] [varchar](100) NOT NULL,
	[CapacityInitial] [varchar](100) NOT NULL,
	[CapacityMaximun] [varchar](100) NOT NULL,
	[CapacityMinimun] [varchar](100) NOT NULL,
	[SupportGlobal] [varchar](100) NOT NULL,
	[StatementCache] [varchar](100) NOT NULL,
	[InactiveConnection] [varchar](100) NOT NULL,
	[TestConnection] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SolicitudConfigApp11gDataSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gDataSource]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudConfigApp11gDataSource_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gDataSource] CHECK CONSTRAINT [FK_SolicitudConfigApp11gDataSource_Solicitud]
GO

