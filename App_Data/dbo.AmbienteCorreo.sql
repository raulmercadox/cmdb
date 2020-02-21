USE [cmdb]
GO

/****** Object:  Table [dbo].[AmbienteCorreo]    Script Date: 02/25/2015 11:00:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AmbienteCorreo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AmbienteId] [int] NOT NULL,
	[Correo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_AmbienteCorreo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[AmbienteCorreo]  WITH CHECK ADD  CONSTRAINT [FK_AmbienteCorreo_Ambiente] FOREIGN KEY([AmbienteId])
REFERENCES [dbo].[Ambiente] ([Id])
GO

ALTER TABLE [dbo].[AmbienteCorreo] CHECK CONSTRAINT [FK_AmbienteCorreo_Ambiente]
GO

ALTER TABLE [dbo].[AmbienteCorreo] ADD  CONSTRAINT [DF_AmbienteCorreo_AmbienteId]  DEFAULT ('') FOR [AmbienteId]
GO

