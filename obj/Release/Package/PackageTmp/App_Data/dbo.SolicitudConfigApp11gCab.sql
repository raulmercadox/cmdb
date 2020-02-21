USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudConfigApp11gCab]    Script Date: 01/12/2016 11:51:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudConfigApp11gCab](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Observaciones] [varchar](max) NOT NULL,
	[ServidorDestino] [varchar](100) NOT NULL,
 CONSTRAINT [PK_SolicitudConfigApp11gCab] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gCab]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudConfigApp11gCab_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudConfigApp11gCab] CHECK CONSTRAINT [FK_SolicitudConfigApp11gCab_Solicitud]
GO

