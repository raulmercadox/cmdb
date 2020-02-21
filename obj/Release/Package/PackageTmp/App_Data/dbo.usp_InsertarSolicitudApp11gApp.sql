CREATE procedure dbo.usp_InsertarSolicitudApp11gApp
@solicitudid int,
@numeroarchivo int,
@Responsable varchar(100),
@AnalistaDesarrollo varchar(100),
@RutaOrigen varchar(500),
@Accion varchar(100),
@Tipo varchar(100),
@Aplicacion varchar(100),
@ServerCluster varchar(MAX),
@Observacion varchar(100),
@TieneParametros varchar(100)
as
insert into dbo.SolicitudApp11gApp (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,RutaOrigen,Accion,Tipo,Aplicacion,ServerCluster,Observacion,TieneParametros)
values (@solicitudid,@numeroarchivo,@Responsable,@AnalistaDesarrollo,@RutaOrigen,@Accion,@Tipo,@Aplicacion,@ServerCluster,@Observacion,@TieneParametros)

select @@IDENTITY