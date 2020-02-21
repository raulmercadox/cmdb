alter procedure dbo.usp_ObtenerProyectoAmbiente
@proyectoid int,
@ambienteid int
as
select Id,ProyectoId,AmbienteId,FechaPase
from dbo.ProyectoAmbiente
where ProyectoId=@proyectoid and AmbienteId=@ambienteid