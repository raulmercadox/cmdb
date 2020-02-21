create procedure dbo.usp_EliminarSolicitudCrmOpcionesCab
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCRMOpcionesCAB where SolicitudId=@solicitudid and NumeroArchivo=@NumeroArchivo