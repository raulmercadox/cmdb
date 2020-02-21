create procedure dbo.usp_EliminarSolicitudSOAEAR
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOAEAR where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo
