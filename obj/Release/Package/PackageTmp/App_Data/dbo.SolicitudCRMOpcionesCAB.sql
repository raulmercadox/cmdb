USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudCRMOpcionesCAB]    Script Date: 03/21/2016 16:11:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudCRMOpcionesCAB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[CodigoProyecto] [varchar](50) NOT NULL,
	[Ambiente] [varchar](50) NOT NULL,
	[Instancia] [varchar](50) NOT NULL,
	[Observaciones] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SolicitudCRMOpcionesCAB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudCRMOpcionesCAB]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCRMOpcionesCAB_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudCRMOpcionesCAB] CHECK CONSTRAINT [FK_SolicitudCRMOpcionesCAB_Solicitud]
GO

