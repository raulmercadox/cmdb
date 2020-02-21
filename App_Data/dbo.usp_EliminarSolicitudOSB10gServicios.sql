create procedure dbo.usp_EliminarSolicitudOSB10gServicios
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudOSB10gServicios where SolicitudId=@solicitudid and NumeroArchivo=@numeroarchivo