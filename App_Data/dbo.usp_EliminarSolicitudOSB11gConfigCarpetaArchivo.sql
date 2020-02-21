create procedure dbo.usp_EliminarSolicitudOSB11gConfigCarpetaArchivo
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB11gConfigCarpetaArchivo
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo