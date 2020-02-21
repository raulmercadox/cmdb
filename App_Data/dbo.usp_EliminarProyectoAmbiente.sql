create procedure dbo.usp_EliminarProyectoAmbiente
@proyectoid int
as
delete from dbo.proyectoambiente where proyectoid=@proyectoid