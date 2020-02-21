alter procedure [dbo].[usp_ObtenerArea]
@id int
as
select id,nombre,color,abreviatura
from dbo.Area
where Id = @id