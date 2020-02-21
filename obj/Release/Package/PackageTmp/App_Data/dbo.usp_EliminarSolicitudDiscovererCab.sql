create procedure dbo.usp_EliminarSolicitudDiscovererCab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SOlicitudDiscovererCab where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo