create procedure dbo.usp_EliminarSolicitudOSB11gConfigColas
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB11gConfigColas
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo