create procedure dbo.usp_InsertarSolicitudOSB10gConfigServer
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@Parametro varchar(50),
@Valor varchar(50),
@Detalles varchar(100)
as
insert into dbo.SolicitudOSB10gConfigServer(SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Parametro,Valor,Detalles)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Parametro,@Valor,@Detalles)

select @@IDENTITY