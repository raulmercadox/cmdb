create procedure dbo.usp_EliminarAprobacion
@aprobacionid int
as
delete from dbo.SolicitudAprobacion where id=@aprobacionid