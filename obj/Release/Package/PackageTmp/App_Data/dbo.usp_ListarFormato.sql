alter procedure dbo.usp_ListarFormato
@nombre varchar(50)
as
select Id,Nombre,Descripcion,Codigo,[Version],CarpetaBase
from dbo.Formato
where Nombre like '%'+@nombre+'%'
order by Nombre