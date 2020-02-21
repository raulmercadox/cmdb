create procedure dbo.usp_InsertarSolicitudSOABPEL
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@RutaOrigen varchar(100),
@Dominio varchar(50),
@ProyectoBPEL varchar(50),
@Observacion varchar(100),
@Parametros varchar(50)
as
insert into dbo.SolicitudSOABPEL(SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,RutaOrigen,Dominio,ProyectoBPEL,Observacion,Parametros)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@RutaOrigen,@Dominio,@ProyectoBPEL,@Observacion,@Parametros)

select @@IDENTITY