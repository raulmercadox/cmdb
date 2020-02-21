create procedure dbo.usp_EliminarSolicitudDiscovererObjetos
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SOlicitudDiscovererObjetos where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo