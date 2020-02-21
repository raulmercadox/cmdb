create procedure dbo.usp_EliminarSolicitudCrmConfigCarpetaArchivo
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCrmConfigCarpetaArchivo where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo