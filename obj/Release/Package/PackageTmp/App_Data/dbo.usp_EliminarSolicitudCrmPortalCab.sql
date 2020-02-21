create procedure dbo.usp_EliminarSolicitudCrmPortalCab
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCRMPortalCab where solicitudId=@solicitudid and numeroArchivo=@numeroarchivo