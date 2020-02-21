USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudCRMConfigDataSource]    Script Date: 03/18/2016 18:42:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudCRMConfigDataSource](
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
 CONSTRAINT [PK_SolicitudCRMConfigDataSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudCRMConfigDataSource]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCRMConfigDataSource_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudCRMConfigDataSource] CHECK CONSTRAINT [FK_SolicitudCRMConfigDataSource_Solicitud]
GO

