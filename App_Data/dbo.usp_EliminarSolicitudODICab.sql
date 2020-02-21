create procedure dbo.usp_EliminarSolicitudODICab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudODICab where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo