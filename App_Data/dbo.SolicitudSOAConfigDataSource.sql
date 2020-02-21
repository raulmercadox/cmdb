USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudSOAConfigDataSource]    Script Date: 04/05/2016 17:59:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudSOAConfigDataSource](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Container] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[JNDILocation] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[ConnectionPool] [varchar](50) NOT NULL,
	[Opciones] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudSOAConfigDataSource] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudSOAConfigDataSource]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudSOAConfigDataSource_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudSOAConfigDataSource] CHECK CONSTRAINT [FK_SolicitudSOAConfigDataSource_Solicitud]
GO

