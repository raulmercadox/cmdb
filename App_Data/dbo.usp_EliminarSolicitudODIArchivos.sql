create procedure dbo.usp_EliminarSolicitudODIArchivos
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudODIArchivos where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo