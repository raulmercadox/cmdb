create procedure dbo.usp_InsertarSolicitudCRMPortalPortal
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Grupo varchar(50),
@Tipo varchar(50),
@NombreObjeto varchar(50),
@Accion varchar(50),
@Permisos varchar(50),
@Observacion varchar(50)
as
insert into dbo.SolicitudCRMPortalPortal (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Grupo,Tipo,NombreObjeto,Accion,Permisos,Observacion)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Grupo,@Tipo,@NombreObjeto,@Accion,@Permisos,@Observacion)

select @@IDENTITY