USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudCRMOpcionesOpciones]    Script Date: 03/21/2016 09:38:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudCRMOpcionesOpciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[ModuloAplicacion] [varchar](50) NOT NULL,
	[Nro] [varchar](50) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[Url] [varchar](50) NOT NULL,
	[ParentId] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudCRMOpcionesOpciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudCRMOpcionesOpciones]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCRMOpcionesOpciones_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudCRMOpcionesOpciones] CHECK CONSTRAINT [FK_SolicitudCRMOpcionesOpciones_Solicitud]
GO

