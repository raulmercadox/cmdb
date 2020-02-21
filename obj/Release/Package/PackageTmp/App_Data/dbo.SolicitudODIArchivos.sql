USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudODIArchivos]    Script Date: 03/23/2016 16:02:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudODIArchivos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[RutaOrigen] [varchar](100) NOT NULL,
	[ServidorDestino] [varchar](50) NOT NULL,
	[RutaDestino] [varchar](100) NOT NULL,
	[NombreArchivo] [varchar](50) NOT NULL,
	[Observacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudODIArchivos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudODIArchivos]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudODIArchivos_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudODIArchivos] CHECK CONSTRAINT [FK_SolicitudODIArchivos_Solicitud]
GO

