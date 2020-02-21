USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudSOAConfigInstanciasJ2EE]    Script Date: 04/05/2016 18:00:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudSOAConfigInstanciasJ2EE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[PuertoRMI] [varchar](50) NOT NULL,
	[MaximumHeap] [varchar](50) NOT NULL,
	[InitialHeap] [varchar](50) NOT NULL,
	[OpcionesAdicionales] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudSOAConfigInstanciasJ2EE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudSOAConfigInstanciasJ2EE]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudSOAConfigInstanciasJ2EE_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudSOAConfigInstanciasJ2EE] CHECK CONSTRAINT [FK_SolicitudSOAConfigInstanciasJ2EE_Solicitud]
GO

