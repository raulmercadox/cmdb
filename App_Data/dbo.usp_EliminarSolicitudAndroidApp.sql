create procedure dbo.usp_EliminarSolicitudAndroidApp
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudAndroidApp where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo