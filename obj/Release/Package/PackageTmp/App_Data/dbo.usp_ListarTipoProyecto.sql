CREATE procedure [dbo].[usp_ListarTipoProyecto]
@nombre varchar(50)
as
select id, nombre
from dbo.TipoProyecto
where nombre like case when @nombre='' then '%%' else '%'+@nombre+'%' end
order by Nombre