create procedure dbo.usp_InsertarSolicitudConfigApp11gCertificado
@solicitudid int,
@numeroarchivo int,
@responsable varchar(100),
@analistadesarrollo varchar(100),
@accion varchar(100),
@nombre varchar(100),
@rutaorigen varchar(500),
@rutadestino varchar(500),
@servidoresdestino varchar(500),
@observacion varchar(100)
as
insert into dbo.SolicitudConfigApp11gCertificado (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,RutaOrigen,RutaDestino,ServidoresDestino,Observacion)
values (@solicitudid,@numeroarchivo,@responsable,@analistadesarrollo,@accion,@nombre,@rutaorigen,@rutadestino,@servidoresdestino,@observacion)

select @@IDENTITY