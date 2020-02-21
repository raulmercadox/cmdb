USE [cmdb]
GO

/****** Object:  Table [dbo].[ProyectoCertificado]    Script Date: 06/14/2015 19:12:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProyectoCertificado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProyectoId] [int] NOT NULL,
	[AmbienteId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[Certificado] [bit] NOT NULL,
 CONSTRAINT [PK_ProyectoCertificado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProyectoCertificado]  WITH CHECK ADD  CONSTRAINT [FK_ProyectoCertificado_Ambiente] FOREIGN KEY([AmbienteId])
REFERENCES [dbo].[Ambiente] ([Id])
GO

ALTER TABLE [dbo].[ProyectoCertificado] CHECK CONSTRAINT [FK_ProyectoCertificado_Ambiente]
GO

ALTER TABLE [dbo].[ProyectoCertificado]  WITH CHECK ADD  CONSTRAINT [FK_ProyectoCertificado_Proyecto] FOREIGN KEY([ProyectoId])
REFERENCES [dbo].[Proyecto] ([Id])
GO

ALTER TABLE [dbo].[ProyectoCertificado] CHECK CONSTRAINT [FK_ProyectoCertificado_Proyecto]
GO

ALTER TABLE [dbo].[ProyectoCertificado]  WITH CHECK ADD  CONSTRAINT [FK_ProyectoCertificado_Usuario] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO

ALTER TABLE [dbo].[ProyectoCertificado] CHECK CONSTRAINT [FK_ProyectoCertificado_Usuario]
GO

