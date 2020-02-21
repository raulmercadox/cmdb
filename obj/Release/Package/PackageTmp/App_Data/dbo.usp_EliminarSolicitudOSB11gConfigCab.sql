create procedure dbo.usp_EliminarSolicitudOSB11gConfigCab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB11gConfigCab
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo