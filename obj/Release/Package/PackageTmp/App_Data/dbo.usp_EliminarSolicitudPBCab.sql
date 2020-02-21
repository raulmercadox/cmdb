create procedure dbo.usp_EliminarSolicitudPBCab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudPBCab where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo