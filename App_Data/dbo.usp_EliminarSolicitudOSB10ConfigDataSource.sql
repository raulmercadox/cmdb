create procedure dbo.usp_EliminarSolicitudOSB10ConfigDataSource
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB10gConfigDataSource
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo