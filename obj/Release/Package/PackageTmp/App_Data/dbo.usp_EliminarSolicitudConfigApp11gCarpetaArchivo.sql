create procedure dbo.usp_EliminarSolicitudConfigApp11gCarpetaArchivo
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudConfigApp11gCarpetaArchivo where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo