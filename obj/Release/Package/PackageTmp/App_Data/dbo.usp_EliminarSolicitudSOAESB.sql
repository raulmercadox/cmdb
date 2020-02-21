create procedure dbo.usp_EliminarSolicitudSOAESB
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOAESB where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo