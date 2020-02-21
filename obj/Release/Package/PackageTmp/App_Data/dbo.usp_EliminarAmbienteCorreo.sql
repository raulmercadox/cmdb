create procedure dbo.usp_EliminarAmbienteCorreo
@ambienteid int
as
delete from dbo.AmbienteCorreo where ambienteId=@ambienteid