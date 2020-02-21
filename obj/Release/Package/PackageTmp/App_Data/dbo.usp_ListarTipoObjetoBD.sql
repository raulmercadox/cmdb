alter procedure [dbo].usp_ListarTipoObjetoBD
@nombre varchar(50)
as
select id, nombre,Extension
from dbo.TipoObjetoBD
where nombre like case when @nombre='' then '%%' else '%'+@nombre+'%' end
order by Nombre