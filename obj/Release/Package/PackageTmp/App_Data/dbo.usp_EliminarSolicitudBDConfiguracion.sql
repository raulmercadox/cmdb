create procedure dbo.usp_EliminarSolicitudBDConfiguracion
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudBDConfiguracion
where SolicitudId=@solicitudid and NumeroArchivo=@numeroarchivo