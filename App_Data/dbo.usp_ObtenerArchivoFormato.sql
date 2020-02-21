alter procedure dbo.usp_ObtenerArchivoFormato
@id int
as
select Contenido,Nombre,Codigo,[Version],CarpetaBase
from dbo.Formato
where id=@id