USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudCRMOpcionesRoles]    Script Date: 03/21/2016 09:39:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudCRMOpcionesRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[ModuloAplicacion] [varchar](50) NOT NULL,
	[Nro] [varchar](50) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[NPCode] [varchar](50) NOT NULL,
	[NPLevel] [varchar](50) NOT NULL,
	[NPModuleId] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudCRMOpcionesRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudCRMOpcionesRoles]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCRMOpcionesRoles_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudCRMOpcionesRoles] CHECK CONSTRAINT [FK_SolicitudCRMOpcionesRoles_Solicitud]
GO

