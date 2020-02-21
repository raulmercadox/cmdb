create procedure dbo.usp_EliminarSolicitudSOAConfigDataSource
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOAConfigDataSource
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo