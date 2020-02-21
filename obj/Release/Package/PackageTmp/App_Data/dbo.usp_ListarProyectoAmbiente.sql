alter procedure dbo.usp_ListarProyectoAmbiente
@proyectoid int
as
select ID, proyectoid,ambienteid,fechapase
from dbo.proyectoambiente
where proyectoid=@proyectoid