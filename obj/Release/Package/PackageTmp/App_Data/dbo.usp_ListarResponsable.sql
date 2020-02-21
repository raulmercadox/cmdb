CREATE procedure [dbo].[usp_ListarResponsable]
@nombre varchar(50)
as
select id, nombre
from dbo.Responsable
where nombre like '%' + @nombre + '%'
order by nombre