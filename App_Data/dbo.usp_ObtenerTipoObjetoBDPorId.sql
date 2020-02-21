alter procedure dbo.usp_ObtenerTipoObjetoBDPorId
@id int
as
select Id,nombre,Extension
from dbo.TipoObjetoBD
where Id=@id