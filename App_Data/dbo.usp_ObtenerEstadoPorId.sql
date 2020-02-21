create procedure dbo.usp_ObtenerEstadoPorId
@id int
as
select ID,nombre,EnviarCorreo,Satisfactorio,Pendiente
from dbo.Estado 
where id=@id