USE [cmdb]
GO

/****** Object:  Table [dbo].[ServidorUsuario]    Script Date: 06/30/2016 12:38:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ServidorUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServidorId] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ServidorUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ServidorUsuario]  WITH CHECK ADD  CONSTRAINT [FK_ServidorUsuario_Servidor] FOREIGN KEY([ServidorId])
REFERENCES [dbo].[Servidor] ([Id])
GO

ALTER TABLE [dbo].[ServidorUsuario] CHECK CONSTRAINT [FK_ServidorUsuario_Servidor]
GO

