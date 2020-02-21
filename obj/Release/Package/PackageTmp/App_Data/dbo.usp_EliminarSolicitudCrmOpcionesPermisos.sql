create procedure dbo.usp_EliminarSolicitudCrmOpcionesPermisos
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCRMOpcionesPermisos where SolicitudId=@solicitudid and NumeroArchivo=@NumeroArchivo
