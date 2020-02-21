create procedure dbo.usp_EliminarSolicitudOSB11gAplicaciones
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudOSB11gAplicaciones where SolicitudId=@solicitudid and NumeroArchivo=@numeroarchivo