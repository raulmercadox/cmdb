create procedure dbo.usp_EliminarSolicitudTomcatApp
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudTomcatApp where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo