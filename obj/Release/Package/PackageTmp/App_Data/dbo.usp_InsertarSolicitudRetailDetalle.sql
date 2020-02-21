create procedure dbo.usp_InsertarSolicitudRetailDetalle
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@RutaOrigen varchar(50),
@Container varchar(50),
@NombreAplicacion varchar(50),
@Observacion varchar(100),
@Parametros varchar(50)
as
insert into dbo.SolicitudRetailDetalle (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,RutaOrigen,Container,NombreAplicacion,Observacion,Parametros)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@RutaOrigen,@Container,@NombreAplicacion,@Observacion,@Parametros)

select @@IDENTITY