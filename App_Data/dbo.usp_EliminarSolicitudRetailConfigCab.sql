create procedure dbo.usp_EliminarSolicitudRetailConfigCab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudRetailConfigCab where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo