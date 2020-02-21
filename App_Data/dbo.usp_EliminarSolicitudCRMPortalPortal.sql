create procedure dbo.usp_EliminarSolicitudCRMPortalPortal
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCRMPortalPortal where solicitudid=@solicitudid and numeroarchivo=@numeroarchivo