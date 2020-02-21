create procedure dbo.usp_EliminarSolicitudOSB10gCab
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudOSB10gCab where SolicitudId=@solicitudid and NumeroArchivo=@numeroarchivo
