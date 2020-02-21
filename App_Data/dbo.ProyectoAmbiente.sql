USE [cmdb]
GO

/****** Object:  Table [dbo].[ProyectoAmbiente]    Script Date: 04/10/2015 12:50:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProyectoAmbiente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProyectoId] [int] NOT NULL,
	[AmbienteId] [int] NOT NULL,
	[FechaPase] [datetime] NOT NULL,
 CONSTRAINT [PK_ProyectoAmbiente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ProyectoAmbiente]  WITH CHECK ADD  CONSTRAINT [FK_ProyectoAmbiente_Ambiente] FOREIGN KEY([AmbienteId])
REFERENCES [dbo].[Ambiente] ([Id])
GO

ALTER TABLE [dbo].[ProyectoAmbiente] CHECK CONSTRAINT [FK_ProyectoAmbiente_Ambiente]
GO

ALTER TABLE [dbo].[ProyectoAmbiente]  WITH CHECK ADD  CONSTRAINT [FK_ProyectoAmbiente_Proyecto] FOREIGN KEY([ProyectoId])
REFERENCES [dbo].[Proyecto] ([Id])
GO

ALTER TABLE [dbo].[ProyectoAmbiente] CHECK CONSTRAINT [FK_ProyectoAmbiente_Proyecto]
GO

