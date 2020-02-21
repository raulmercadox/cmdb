create procedure dbo.usp_ObtenerSolicitudEstado
@solicitudid int
as
select e.Id,e.Nombre,e.Pendiente,e.Satisfactorio,e.EnviarCorreo
from dbo.Solicitud s 
inner join dbo.Estado e on s.Estado = e.Nombre
where s.Id=@solicitudid