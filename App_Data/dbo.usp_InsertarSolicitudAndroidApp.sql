CREATE procedure dbo.usp_InsertarSolicitudAndroidApp
@solicitudid int,
@numeroarchivo int,
@Responsable varchar(100),
@AnalistaDesarrollo varchar(100),
@Accion varchar(100),
@Nombre varchar(100),
@RutaOrigen varchar(500),
@RutaDestino varchar(500),
@ServidorDestino varchar(100),
@Observacion varchar(100),
@TieneParametros varchar(100)
as
insert into dbo.SolicitudAndroidApp (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,RutaOrigen,RutaDestino,ServidorDestino,Observacion,TieneParametros)
values (@solicitudid,@numeroarchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Nombre,@RutaOrigen,@RutaDestino,@ServidorDestino,@Observacion,@TieneParametros)

select @@IDENTITY