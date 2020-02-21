create procedure dbo.usp_EliminarSolicitudOSB11gCab
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudOSB11gCab where SolicitudId=@solicitudid and NumeroArchivo=@numeroarchivo
