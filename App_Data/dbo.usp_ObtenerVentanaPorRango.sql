alter procedure dbo.usp_ObtenerVentanaPorRango
@desde DateTime,
@hasta DateTime = null
as
select id,desde,hasta
from dbo.Ventana
where DATEPART(HOUR,desde)=DATEPART(HOUR,@desde) and DATEPART(MINUTE,desde)=DATEPART(MINUTE,@desde)
and DATEPART(HOUR,hasta)=DATEPART(HOUR,@hasta) and DATEPART(MINUTE,hasta)=DATEPART(MINUTE,@hasta)