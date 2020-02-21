alter procedure dbo.usp_ObtenerAreaPorNombre
@nombre varchar(100)
as
select Id,Nombre,Color,Abreviatura
from dbo.Area
where Nombre = @Nombre