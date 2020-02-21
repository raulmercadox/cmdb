create procedure dbo.usp_ListarProyectoCorreo
@ProyectoId int
as
select Id,Correo
from dbo.ProyectoCorreo
where ProyectoId=@ProyectoId