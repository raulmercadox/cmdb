USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudRetailCab]    Script Date: 04/04/2016 15:18:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudRetailCab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[CodigoProyecto] [varchar](50) NOT NULL,
	[Ambiente] [varchar](50) NOT NULL,
	[ServidorDestino] [varchar](50) NOT NULL,
	[Observaciones] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SolicitudRetailCab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudRetailCab]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudRetailCab_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudRetailCab] CHECK CONSTRAINT [FK_SolicitudRetailCab_Solicitud]
GO

