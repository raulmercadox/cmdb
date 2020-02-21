create procedure dbo.usp_EliminarSolicitudOSB11gConfigAdaptadores
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB11gConfigAdaptadores
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo