create procedure dbo.usp_EliminarSolicitudReportesDetalle
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudReportesDetalle where SolicitudId=@SolicitudId and NumeroArchivo = @NumeroArchivo