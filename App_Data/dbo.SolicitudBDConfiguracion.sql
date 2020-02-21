USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudBDConfiguracion]    Script Date: 03/12/2015 10:30:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudBDConfiguracion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[InstanciaId] [int] NOT NULL,
	[EsquemaId] [int] NOT NULL,
	[Tabla] [varchar](50) NOT NULL,
	[Comentario] [varchar](max) NOT NULL,
	[Archivo] [varchar](100) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudBDConfiguracion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudBDConfiguracion]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudBDConfiguracion_Esquema] FOREIGN KEY([EsquemaId])
REFERENCES [dbo].[Esquema] ([Id])
GO

ALTER TABLE [dbo].[SolicitudBDConfiguracion] CHECK CONSTRAINT [FK_SolicitudBDConfiguracion_Esquema]
GO

ALTER TABLE [dbo].[SolicitudBDConfiguracion]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudBDConfiguracion_Instancia] FOREIGN KEY([InstanciaId])
REFERENCES [dbo].[Instancia] ([Id])
GO

ALTER TABLE [dbo].[SolicitudBDConfiguracion] CHECK CONSTRAINT [FK_SolicitudBDConfiguracion_Instancia]
GO

ALTER TABLE [dbo].[SolicitudBDConfiguracion]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudBDConfiguracion_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudBDConfiguracion] CHECK CONSTRAINT [FK_SolicitudBDConfiguracion_Solicitud]
GO

