create procedure dbo.usp_ObtenerEsquemaPorId
@id int
as
select id,nombre,instanciaid
from dbo.Esquema
where id=@id