create procedure dbo.usp_EliminarSolicitudReportesCab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudReportesCab where SolicitudId=@SolicitudId and NumeroArchivo = @NumeroArchivo