create procedure dbo.usp_EliminarSolicitudIXMediationObjetos
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudIXMediationObjetos where solicitudid=@solicitudid and numeroarchivo=@numeroarchivo