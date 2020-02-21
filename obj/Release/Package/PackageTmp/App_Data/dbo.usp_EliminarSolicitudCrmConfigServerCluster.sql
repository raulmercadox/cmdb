create procedure dbo.usp_EliminarSolicitudCrmConfigServerCluster
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCrmConfigServerCluster where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo