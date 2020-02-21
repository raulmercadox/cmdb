create procedure dbo.usp_EliminarSolicitudCrmConfigCertificado
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCrmConfigCertificado where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo