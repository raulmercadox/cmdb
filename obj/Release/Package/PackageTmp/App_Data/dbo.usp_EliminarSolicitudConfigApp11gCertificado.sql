create procedure dbo.usp_EliminarSolicitudConfigApp11gCertificado
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudConfigApp11gCertificado where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo