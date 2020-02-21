create procedure dbo.usp_EliminarSolicitudSOAConfigArchivos
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOAConfigArchivos
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo