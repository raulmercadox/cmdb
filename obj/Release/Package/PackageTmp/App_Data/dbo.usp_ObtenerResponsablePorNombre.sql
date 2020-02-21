CREATE procedure [dbo].[usp_ObtenerResponsablePorNombre]
@nombre varchar(50)
as
select id,nombre
from dbo.Responsable
where nombre = @nombre
order by nombre
