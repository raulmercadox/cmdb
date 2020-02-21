create procedure dbo.usp_EliminarSolicitudCrmConfigDataSource
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCrmConfigDataSource where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo