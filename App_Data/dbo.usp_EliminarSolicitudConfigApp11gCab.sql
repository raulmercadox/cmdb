create procedure dbo.usp_EliminarSolicitudConfigApp11gCab
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudConfigApp11gCab where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo