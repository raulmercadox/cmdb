USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudBDCampo]    Script Date: 02/20/2015 12:23:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudBDCampo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[InstanciaId] [int] NOT NULL,
	[EsquemaId] [int] NOT NULL,
	[NombreTabla] [varchar](50) NOT NULL,
	[TipoAccionBDId] [int] NOT NULL,
	[NombreColumna] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Comentario] [varchar](max) NOT NULL,
	[NotNull] [varchar](1) NOT NULL,
	[DefaultValue] [varchar](50) NOT NULL,
	[CheckValue] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudBDCampos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudBDCampo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudBDCampos_Esquema] FOREIGN KEY([EsquemaId])
REFERENCES [dbo].[Esquema] ([Id])
GO

ALTER TABLE [dbo].[SolicitudBDCampo] CHECK CONSTRAINT [FK_SolicitudBDCampos_Esquema]
GO

ALTER TABLE [dbo].[SolicitudBDCampo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudBDCampos_Instancia] FOREIGN KEY([InstanciaId])
REFERENCES [dbo].[Instancia] ([Id])
GO

ALTER TABLE [dbo].[SolicitudBDCampo] CHECK CONSTRAINT [FK_SolicitudBDCampos_Instancia]
GO

ALTER TABLE [dbo].[SolicitudBDCampo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudBDCampos_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudBDCampo] CHECK CONSTRAINT [FK_SolicitudBDCampos_Solicitud]
GO

ALTER TABLE [dbo].[SolicitudBDCampo]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudBDCampos_TipoAccionBD] FOREIGN KEY([TipoAccionBDId])
REFERENCES [dbo].[TipoAccionBD] ([Id])
GO

ALTER TABLE [dbo].[SolicitudBDCampo] CHECK CONSTRAINT [FK_SolicitudBDCampos_TipoAccionBD]
GO

