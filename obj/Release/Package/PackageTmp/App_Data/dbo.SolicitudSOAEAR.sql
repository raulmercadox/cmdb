USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudSOAEAR]    Script Date: 04/05/2016 11:12:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudSOAEAR](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[RutaOrigen] [varchar](100) NOT NULL,
	[Container] [varchar](50) NOT NULL,
	[NombreAplicacion] [varchar](50) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[Parametros] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudSOAEAR] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudSOAEAR]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudSOAEAR_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudSOAEAR] CHECK CONSTRAINT [FK_SolicitudSOAEAR_Solicitud]
GO

