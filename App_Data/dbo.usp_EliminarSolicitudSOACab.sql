create procedure dbo.usp_EliminarSolicitudSOACab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOACab where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo