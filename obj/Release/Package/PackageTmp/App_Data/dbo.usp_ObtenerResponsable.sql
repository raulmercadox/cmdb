CREATE procedure [dbo].[usp_ObtenerResponsable]
@id int
as
select id,nombre
from dbo.Responsable
where id = @id