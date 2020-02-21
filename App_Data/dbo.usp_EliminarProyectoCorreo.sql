create procedure dbo.usp_EliminarProyectoCorreo
@Id int
as
delete from dbo.ProyectoCorreo where Id=@Id