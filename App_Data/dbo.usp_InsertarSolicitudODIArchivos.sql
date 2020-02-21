create procedure dbo.usp_InsertarSolicitudODIArchivos
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@RutaOrigen varchar(100),
@ServidorDestino varchar(50),
@RutaDestino varchar(100),
@NombreArchivo varchar(50),
@Observacion varchar(50)
as
insert into dbo.SolicitudODIArchivos(SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,RutaOrigen,ServidorDestino,RutaDestino,NombreArchivo,Observacion)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@RutaOrigen,@ServidorDestino,@RutaDestino,@NombreArchivo,@Observacion)

select @@IDENTITY