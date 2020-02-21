create procedure [dbo].[usp_ObtenerTipoProyectoPorId]
@id int
as
select Id,nombre
from dbo.TipoProyecto
where Id=@id
