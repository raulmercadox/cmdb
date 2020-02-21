USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudPBLibrerias]    Script Date: 04/04/2016 10:28:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudPBLibrerias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Orden] [varchar](50) NOT NULL,
	[GrupoDesarrollo] [varchar](50) NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Servidor] [varchar](50) NOT NULL,
	[Ruta] [varchar](100) NOT NULL,
	[Libreria] [varchar](50) NOT NULL,
	[Objeto] [varchar](50) NOT NULL,
	[LibreriaDestino] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudPBLibrerias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudPBLibrerias]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudPBLibrerias_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudPBLibrerias] CHECK CONSTRAINT [FK_SolicitudPBLibrerias_Solicitud]
GO

