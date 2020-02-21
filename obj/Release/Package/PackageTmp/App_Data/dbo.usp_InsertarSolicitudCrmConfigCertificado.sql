create procedure dbo.usp_InsertarSolicitudCrmConfigCertificado
@solicitudid int,
@numeroarchivo int,
@responsable varchar(100),
@analistadesarrollo varchar(100),
@accion varchar(100),
@nombre varchar(100),
@rutaorigen varchar(500),
@rutadestino varchar(500),
@observacion varchar(100)
as
insert into dbo.SolicitudCrmConfigCertificado (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,RutaOrigen,RutaDestino,Observacion)
values (@solicitudid,@numeroarchivo,@responsable,@analistadesarrollo,@accion,@nombre,@rutaorigen,@rutadestino,@observacion)

select @@IDENTITY