alter procedure dbo.usp_ObtenerTipoObjetoBD
@nombre varchar(50)
as
select Id,nombre,extension
from dbo.TipoObjetoBD
where Nombre=@nombre