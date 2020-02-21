alter procedure dbo.usp_ListarVentana
as
select id,desde,hasta
from dbo.Ventana
order by datepart(hour,desde),DATEPART(minute,desde)