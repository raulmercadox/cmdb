create procedure dbo.usp_ObtenerFormatoPorPropiedadNombre
@propiedadNombre varchar(20)
as
select Codigo,[Version],CarpetaBase
from dbo.Formato
where Codigo=@propiedadNombre