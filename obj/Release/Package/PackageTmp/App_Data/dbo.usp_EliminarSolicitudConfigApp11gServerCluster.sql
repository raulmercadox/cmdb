create procedure dbo.usp_EliminarSolicitudConfigApp11gServerCluster
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudConfigApp11gServerCluster where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo	