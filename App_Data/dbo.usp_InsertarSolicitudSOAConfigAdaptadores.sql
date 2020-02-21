create procedure dbo.usp_InsertarSolicitudSOAConfigAdaptadores
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@JNDILocation varchar(50),
@ConnectionFactory varchar(50),
@ConnectionInterface varchar(50),
@Atributo varchar(50),
@OpcionesAdicionales varchar(50)
as
insert into dbo.SolicitudSOAConfigAdaptadores (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,JNDILocation,ConnectionFactory,ConnectionInterface,Atributo,OpcionesAdicionales)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@JNDILocation,@ConnectionFactory,@ConnectionInterface,@Atributo,@OpcionesAdicionales)

select @@IDENTITY