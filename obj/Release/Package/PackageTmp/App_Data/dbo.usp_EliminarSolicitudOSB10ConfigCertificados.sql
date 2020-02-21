create procedure dbo.usp_EliminarSolicitudOSB10ConfigCertificados
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB10gConfigCertificados
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo