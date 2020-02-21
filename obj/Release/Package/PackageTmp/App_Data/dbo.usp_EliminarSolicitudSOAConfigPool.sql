create procedure dbo.usp_EliminarSolicitudSOAConfigPool
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOAConfigPool
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo