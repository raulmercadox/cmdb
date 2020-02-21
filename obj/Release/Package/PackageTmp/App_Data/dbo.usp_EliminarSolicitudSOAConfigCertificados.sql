create procedure dbo.usp_EliminarSolicitudSOAConfigCertificados
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOAConfigCertificados
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo