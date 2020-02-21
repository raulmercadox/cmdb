create procedure dbo.usp_InsertarSolicitudSOAConfigArchivos
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@Nombre varchar(50),
@RutaOrigen varchar(100),
@RutaDestino varchar(100),
@ServidoresDestino varchar(50),
@Observacion varchar(100),
@Parametros varchar(50)
as
insert into dbo.SolicitudSOAConfigArchivos (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,RutaOrigen,RutaDestino,ServidoresDestino,Observacion,Parametros)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Nombre,@RutaOrigen,@RutaDestino,@ServidoresDestino,@Observacion,@Parametros)

select @@IDENTITY