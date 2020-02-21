create procedure dbo.usp_EliminarSolicitudRetailCab
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudRetailCab where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo