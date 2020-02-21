USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudIXMediationObjetos]    Script Date: 03/23/2016 11:45:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudIXMediationObjetos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Orden] [varchar](50) NOT NULL,
	[Directorio] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Observacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudIXMediationObjetos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudIXMediationObjetos]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudIXMediationObjetos_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudIXMediationObjetos] CHECK CONSTRAINT [FK_SolicitudIXMediationObjetos_Solicitud]
GO

