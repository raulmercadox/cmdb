create procedure [dbo].[usp_ObtenerTipoProyecto]
@nombre varchar(50)
as
select Id,nombre
from dbo.TipoProyecto
where Nombre=@nombre