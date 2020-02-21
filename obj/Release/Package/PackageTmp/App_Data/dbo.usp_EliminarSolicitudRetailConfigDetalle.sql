create procedure dbo.usp_EliminarSolicitudRetailConfigDetalle
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudRetailConfigDetalle where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo