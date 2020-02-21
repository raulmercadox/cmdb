create procedure dbo.usp_InsertarSolicitudPBArchivos
@SolicitudId int,
@NumeroArchivo int,
@Orden varchar(50),
@GrupoDesarrollo varchar(50),
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@ServidorOrigen varchar(50),
@RutaOrigen varchar(100),
@ServidorDestino varchar(50),
@NombreArchivo varchar(50),
@Accion varchar(50),
@InformacionAdicional varchar(100)
as
insert into dbo.SolicitudPBArchivos (SolicitudId,NumeroArchivo,Orden,GrupoDesarrollo,Responsable,AnalistaDesarrollo,ServidorOrigen,RutaOrigen,ServidorDestino,
NombreArchivo,Accion,InformacionAdicional)
values (@SolicitudId,@NumeroArchivo,@Orden,@GrupoDesarrollo,@Responsable,@AnalistaDesarrollo,@ServidorOrigen,@RutaOrigen,@ServidorDestino,
@NombreArchivo,@Accion,@InformacionAdicional)

select @@IDENTITY