create procedure dbo.usp_EliminarSolicitudRetailDetalle
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudRetailDetalle where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo