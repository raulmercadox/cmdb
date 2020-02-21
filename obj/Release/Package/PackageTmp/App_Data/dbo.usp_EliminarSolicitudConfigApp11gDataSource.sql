create procedure dbo.usp_EliminarSolicitudConfigApp11gDataSource
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudConfigApp11gDataSource where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo