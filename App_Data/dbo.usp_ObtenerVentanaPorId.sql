create procedure dbo.usp_ObtenerVentanaPorId
@id int
as
select id,desde,hasta
from dbo.Ventana
where id=@id