create procedure dbo.usp_EliminarSolicitudSOABPEL
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOABPEL where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo