USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudCRMPortalPortal]    Script Date: 03/22/2016 14:30:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudCRMPortalPortal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Grupo] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[NombreObjeto] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Permisos] [varchar](50) NOT NULL,
	[Observacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudCRMPortalPortal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudCRMPortalPortal]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCRMPortalPortal_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudCRMPortalPortal] CHECK CONSTRAINT [FK_SolicitudCRMPortalPortal_Solicitud]
GO

