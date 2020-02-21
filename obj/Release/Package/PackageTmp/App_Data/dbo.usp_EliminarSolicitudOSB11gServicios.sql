create procedure dbo.usp_EliminarSolicitudOSB11gServicios
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudOSB11gServicios where SolicitudId=@solicitudid and NumeroArchivo=@numeroarchivo