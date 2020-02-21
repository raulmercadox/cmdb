alter procedure dbo.usp_ObtenerFormatoPorNombre
@nombre varchar(50)
as
select Id,Nombre,Descripcion,Codigo,[Version],CarpetaBase
from dbo.Formato
where nombre=@nombre