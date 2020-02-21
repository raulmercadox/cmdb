USE [cmdb]
GO

/****** Object:  Table [dbo].[SolicitudCRMWPApp]    Script Date: 03/16/2015 12:38:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SolicitudCRMWPApp](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SolicitudId] [int] NOT NULL,
	[NumeroArchivo] [int] NOT NULL,
	[Responsable] [varchar](50) NOT NULL,
	[AnalistaDesarrollo] [varchar](50) NOT NULL,
	[RutaOrigen] [varchar](200) NOT NULL,
	[ServerCluster] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
	[Aplicacion] [varchar](50) NOT NULL,
	[Accion] [varchar](50) NOT NULL,
	[Observacion] [varchar](max) NOT NULL,
	[ParametroAmbiente] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SolicitudCRMWPApp] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SolicitudCRMWPApp]  WITH CHECK ADD  CONSTRAINT [FK_SolicitudCRMWPApp_Solicitud] FOREIGN KEY([SolicitudId])
REFERENCES [dbo].[Solicitud] ([Id])
GO

ALTER TABLE [dbo].[SolicitudCRMWPApp] CHECK CONSTRAINT [FK_SolicitudCRMWPApp_Solicitud]
GO

