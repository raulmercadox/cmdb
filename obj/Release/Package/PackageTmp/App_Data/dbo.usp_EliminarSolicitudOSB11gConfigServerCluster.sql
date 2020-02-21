create procedure dbo.usp_EliminarSolicitudOSB11gConfigServerCluster
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB11gConfigServerCluster
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo