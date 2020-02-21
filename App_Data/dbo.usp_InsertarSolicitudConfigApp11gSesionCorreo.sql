create procedure dbo.usp_InsertarSolicitudConfigApp11gSesionCorreo
@solicitudid int,
@numeroarchivo int,
@responsable varchar(100),
@analistadesarrollo varchar(100),
@accion varchar(100),
@nombre varchar(100),
@servercluster varchar(100),
@jndiname varchar(100),
@javamailproperties varchar(100),
@observacion varchar(100)
as
insert into dbo.SolicitudConfigApp11gSesionCorreo 
(SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,ServerCluster,JndiName,JavaMailProperties,Observacion)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Nombre,@ServerCluster,@JndiName,@JavaMailProperties,@Observacion)

select @@IDENTITY