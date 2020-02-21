create procedure dbo.usp_InsertarSolicitudSOAESB
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@RutaOrigen varchar(100),
@Container varchar(50),
@NombreAplicacion varchar(50),
@Observacion varchar(100),
@Parametros varchar(50)
as
insert into dbo.SolicitudSOAESB (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,RutaOrigen,ServicesGroup,ProyectoESB,Observacion,Parametros)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@RutaOrigen,@ServicesGroup,@ProyectoESB,@Observacion,@Parametros)

select @@IDENTITY