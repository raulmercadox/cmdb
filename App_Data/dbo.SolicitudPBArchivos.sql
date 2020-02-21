USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudPBArchivos]    Script Date: 04/04/2016 10:27:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudPBArchivos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Orden] [varchar](50) NOT NULL,
	[GrupoDesarrollo] [varchar](50) NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[ServidorOrigen] [varchar](50) NOT NULL,
	[RutaOrigen] [varchar](100) NOT NULL,
	[ServidorDestino] [varchar](50) NOT NULL,
	[NombreArchivo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[InformacionAdicional] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SolicitudPBArchivos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudPBArchivos]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudPBArchivos_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudPBArchivos] CHECK CONSTRAINT [FK_SolicitudPBArchivos_Solicitud]
GO

