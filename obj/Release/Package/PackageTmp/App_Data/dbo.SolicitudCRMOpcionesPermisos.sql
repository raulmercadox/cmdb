USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudCRMOpcionesPermisos]    Script Date: 03/21/2016 09:39:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudCRMOpcionesPermisos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Campo1] [varchar](50) NOT NULL,
	[Campo2] [varchar](50) NOT NULL,
	[Campo3] [varchar](50) NOT NULL,
	[Campo4] [varchar](50) NOT NULL,
	[Campo5] [varchar](50) NOT NULL,
	[Campo6] [varchar](50) NOT NULL,
	[Campo7] [varchar](50) NOT NULL,
	[Campo8] [varchar](50) NOT NULL,
	[Campo9] [varchar](50) NOT NULL,
	[Campo10] [varchar](50) NOT NULL,
	[Campo11] [varchar](50) NOT NULL,
	[Campo12] [varchar](50) NOT NULL,
	[Campo13] [varchar](50) NOT NULL,
	[Campo14] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudCRMOpcionesPermisos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudCRMOpcionesPermisos]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCRMOpcionesPermisos_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudCRMOpcionesPermisos] CHECK CONSTRAINT [FK_SolicitudCRMOpcionesPermisos_Solicitud]
GO

