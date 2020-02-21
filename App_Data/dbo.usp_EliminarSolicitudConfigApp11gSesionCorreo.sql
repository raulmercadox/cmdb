create procedure dbo.usp_EliminarSolicitudConfigApp11gSesionCorreo
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudConfigApp11gSesionCorreo where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo