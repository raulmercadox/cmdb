USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudOSB11gConfigColas]    Script Date: 03/31/2016 18:29:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudOSB11gConfigColas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ServerCluster] [varchar](50) NOT NULL,
	[JNDIName] [varchar](100) NOT NULL,
	[Template] [varchar](50) NOT NULL,
	[SubDeployment] [varchar](50) NOT NULL,
	[Target] [varchar](50) NOT NULL,
	[RedeliveryOverride] [varchar](50) NOT NULL,
	[RedeliveryLimit] [varchar](50) NOT NULL,
	[ExpirationPolicy] [varchar](50) NOT NULL,
	[ErrorDestination] [varchar](50) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[ModuloJMS] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudOSB11gConfigColas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigColas]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudOSB11gConfigColas_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudOSB11gConfigColas] CHECK CONSTRAINT [FK_SolicitudOSB11gConfigColas_Solicitud]
GO

