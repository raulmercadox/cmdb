create procedure dbo.usp_InsertarSolicitudOSB10gConfigCarpetaArchivo
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@Nombre varchar(50),
@RutaOrigen varchar(100),
@RutaDestino varchar(100),
@ServidoresDestino varchar(100),
@Observacion varchar(100),
@ParametrosAmbiente varchar(50)
as
insert into dbo.SolicitudOSB10gConfigCarpetaArchivo (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,RutaOrigen,RutaDestino,ServidoresDestino,Observacion,ParametrosAmbiente)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Nombre,@RutaOrigen,@RutaDestino,@ServidoresDestino,@Observacion,@ParametrosAmbiente)

select @@IDENTITY