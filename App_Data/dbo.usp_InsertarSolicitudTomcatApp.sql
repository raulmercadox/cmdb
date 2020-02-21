create procedure dbo.usp_InsertarSolicitudTomcatApp
@solicitudid int,
@numeroarchivo int,
@Responsable varchar(100),
@AnalistaDesarrollo varchar(100),
@RutaOrigen varchar(500),
@RutaDestino varchar(500),
@Tipo varchar(100),
@Aplicacion varchar(100),
@Accion varchar(100),
@Observacion varchar(100),
@TieneParametros varchar(100)
as
insert into dbo.SolicitudTomcatApp (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,RutaOrigen,RutaDestino,Tipo,Aplicacion,Accion,Observacion,TieneParametros)
values (@solicitudid,@numeroarchivo,@Responsable,@AnalistaDesarrollo,@RutaOrigen,@RutaDestino,@Tipo,@Aplicacion,@Accion,@Observacion,@TieneParametros)

select @@IDENTITY