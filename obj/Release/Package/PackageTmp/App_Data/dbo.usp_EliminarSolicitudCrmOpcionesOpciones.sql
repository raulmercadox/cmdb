create procedure dbo.usp_EliminarSolicitudCrmOpcionesOpciones
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudCRMOpcionesOpciones where SolicitudId=@solicitudid and NumeroArchivo=@NumeroArchivo