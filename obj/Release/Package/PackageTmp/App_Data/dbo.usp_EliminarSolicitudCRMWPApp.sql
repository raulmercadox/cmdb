create procedure dbo.usp_EliminarSolicitudCRMWPApp
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCRMWPApp where SolicitudId = @solicitudid and NumeroArchivo = @numeroarchivo