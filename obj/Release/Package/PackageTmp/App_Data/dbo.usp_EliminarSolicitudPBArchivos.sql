create procedure dbo.usp_EliminarSolicitudPBArchivos
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudPBArchivos where SolicitudId=@SolicitudId and NumeroArchivo =@NumeroArchivo