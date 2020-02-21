USE [cmdb]
GO

/****** Object:  Table [dbo].[ProyectoCorreo]    Script Date: 06/24/2016 15:16:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProyectoCorreo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProyectoId] [int] NOT NULL,
	[Correo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ProyectoCorreo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ProyectoCorreo]  WITH CHECK ADD  CONSTRAINT [FK_ProyectoCorreo_Proyecto] FOREIGN KEY([ProyectoId])
REFERENCES [dbo].[Proyecto] ([Id])
GO

ALTER TABLE [dbo].[ProyectoCorreo] CHECK CONSTRAINT [FK_ProyectoCorreo_Proyecto]
GO

