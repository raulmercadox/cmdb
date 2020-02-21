create procedure dbo.usp_EliminarSolicitudOSB10ConfigCarpetaArchivo
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB10gConfigCarpetaArchivo
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo