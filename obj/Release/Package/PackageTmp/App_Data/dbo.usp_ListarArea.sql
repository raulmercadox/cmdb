alter procedure [dbo].[usp_ListarArea]
@nombre varchar(100)
as
select id, nombre, color, Abreviatura
from dbo.Area
where nombre like case when @nombre='' then '%%' else '%'+@nombre+'%' end
order by Nombre