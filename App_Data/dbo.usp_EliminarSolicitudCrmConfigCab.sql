create procedure dbo.usp_EliminarSolicitudCrmConfigCab
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCrmConfigCab where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo