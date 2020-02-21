USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudSOAESB]    Script Date: 04/05/2016 11:13:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudSOAESB](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[RutaOrigen] [varchar](100) NOT NULL,
	[ServicesGroup] [varchar](50) NOT NULL,
	[ProyectoESB] [varchar](50) NOT NULL,
	[Observacion] [varchar](100) NOT NULL,
	[Parametros] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudSOAESB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

