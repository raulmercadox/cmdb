USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudPBCab]    Script Date: 04/04/2016 10:26:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudPBCab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[CodigoProyecto] [varchar](50) NOT NULL,
	[Ambiente] [varchar](50) NOT NULL,
	[Aplicacion] [varchar](50) NOT NULL,
	[TipoPase] [varchar](50) NOT NULL,
	[Observaciones] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SolicitudPBCab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudPBCab]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudPBCab_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudPBCab] CHECK CONSTRAINT [FK_SolicitudPBCab_Solicitud]
GO

