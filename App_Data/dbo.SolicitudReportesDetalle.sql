USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudReportesDetalle]    Script Date: 04/04/2016 12:39:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudReportesDetalle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[RutaOrigen] [varchar](100) NOT NULL,
	[RutaDestino] [varchar](100) NOT NULL,
	[ServidoresDestino] [varchar](100) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SolicitudReportesDetalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudReportesDetalle]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudReportesDetalle_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudReportesDetalle] CHECK CONSTRAINT [FK_SolicitudReportesDetalle_Solicitud]
GO

