create procedure dbo.usp_EliminarSolicitudTomcatCab
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudTomcatCab 
where SolicitudId=@solicitudId and NumeroArchivo=@numeroArchivo