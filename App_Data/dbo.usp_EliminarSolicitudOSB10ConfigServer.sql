create procedure dbo.usp_EliminarSolicitudOSB10ConfigServer
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudOSB10gConfigServer
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo