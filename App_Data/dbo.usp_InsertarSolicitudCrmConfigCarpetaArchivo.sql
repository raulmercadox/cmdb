create procedure dbo.usp_InsertarSolicitudCrmConfigCarpetaArchivo
@solicitudid int,
@numeroarchivo int,
@responsable varchar(100),
@analistadesarrollo varchar(100),
@accion varchar(100),
@nombre varchar(100),
@rutaorigen varchar(500),
@rutadestino varchar(500),
@observacion varchar(100),
@tieneparametros varchar(100)
as
insert into dbo.SolicitudCrmConfigCarpetaArchivo (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,RutaOrigen,RutaDestino,Observacion,TieneParametros)
values (@solicitudid,@numeroarchivo,@responsable,@analistadesarrollo,@accion,@nombre,@rutaorigen,@rutadestino,@observacion,@tieneparametros)

select @@IDENTITY