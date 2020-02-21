create procedure dbo.usp_InsertarSolicitudCRMWPApp
@solicitudid int,
@numeroarchivo int,
@responsable varchar(50),
@analistadesarrollo varchar(50),
@rutaorigen varchar(200),
@servercluster varchar(50),
@tipo varchar(50),
@aplicacion varchar(50),
@accion varchar(50),
@observacion varchar(MAX),
@parametroambiente varchar(50)
as
insert into dbo.SolicitudCRMWPApp (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,RutaOrigen,ServerCluster,Tipo,Aplicacion,Accion,Observacion,ParametroAmbiente)
values (@solicitudid,@numeroarchivo,@responsable,@analistadesarrollo,@rutaorigen,@servercluster,@tipo,@aplicacion,@accion,@observacion,@parametroambiente)

select @@IDENTITY