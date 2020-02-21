create procedure dbo.usp_EliminarSolicitudOSB11gConfigDataSource
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB11gConfigDataSource
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo