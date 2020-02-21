create procedure dbo.usp_EliminarSolicitudOSB10ConfigCab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB10gConfigCab
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo