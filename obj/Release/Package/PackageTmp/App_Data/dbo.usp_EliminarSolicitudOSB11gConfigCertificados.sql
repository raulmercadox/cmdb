create procedure dbo.usp_EliminarSolicitudOSB11gConfigCertificados
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB11gConfigCertificados
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo