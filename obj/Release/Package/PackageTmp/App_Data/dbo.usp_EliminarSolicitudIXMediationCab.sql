create procedure dbo.usp_EliminarSolicitudIXMediationCab
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudIXMediationCab where SolicitudId=@solicitudid and NumeroArchivo=@numeroarchivo