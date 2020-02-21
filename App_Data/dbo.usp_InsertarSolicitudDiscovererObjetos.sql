create procedure dbo.usp_InsertarSolicitudDiscovererObjetos
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Tipo varchar(50),
@NombreObjeto varchar(50),
@Accion varchar(50),
@Observacion varchar(50)
as
insert into dbo.SolicitudDiscovererObjetos (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Tipo,NombreObjeto,Accion,Observacion)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Tipo,@NombreObjeto,@Accion,@Observacion)

select @@IDENTITY