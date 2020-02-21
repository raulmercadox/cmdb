create procedure dbo.usp_EliminarSolicitudSOAConfigAdaptadores
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOAConfigAdaptadores
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo