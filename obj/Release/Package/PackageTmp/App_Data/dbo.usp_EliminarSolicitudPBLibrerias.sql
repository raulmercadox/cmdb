create procedure dbo.usp_EliminarSolicitudPBLibrerias
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudPBLibrerias where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo