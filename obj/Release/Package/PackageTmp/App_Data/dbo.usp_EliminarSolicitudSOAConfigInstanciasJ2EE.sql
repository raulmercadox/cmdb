create procedure dbo.usp_EliminarSolicitudSOAConfigInstanciasJ2EE
@SolicitudId int,
@NumeroArchivo int
as
delete from dbo.SolicitudSOAConfigInstanciasJ2EE
where SolicitudId=@SolicitudId and NumeroArchivo=@NumeroArchivo