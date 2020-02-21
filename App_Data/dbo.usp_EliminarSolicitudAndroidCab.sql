create procedure dbo.usp_EliminarSolicitudAndroidCab
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudAndroidCab where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo