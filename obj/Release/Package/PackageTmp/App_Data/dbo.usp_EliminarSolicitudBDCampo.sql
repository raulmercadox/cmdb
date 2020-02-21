create procedure dbo.usp_EliminarSolicitudBDCampo
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudBDCampo where solicitudid=@solicitudid and numeroarchivo=@numeroarchivo