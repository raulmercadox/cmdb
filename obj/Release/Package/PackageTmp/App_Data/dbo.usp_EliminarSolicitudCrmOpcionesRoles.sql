create procedure dbo.usp_EliminarSolicitudCrmOpcionesRoles
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCRMOpcionesRoles where SolicitudId=@solicitudid and NumeroArchivo=@NumeroArchivo