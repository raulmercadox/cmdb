create procedure dbo.usp_EliminarSolicitudSOAConfigCab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOAConfigCab
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo