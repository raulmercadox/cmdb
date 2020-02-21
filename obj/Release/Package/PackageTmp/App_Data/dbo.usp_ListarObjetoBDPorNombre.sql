create procedure dbo.usp_ListarObjetoBDPorNombre
@nombre varchar(100)
as
select bd.SolicitudId,bd.InstanciaId,bd.EsquemaId,bd.TipoObjetoBDId,bd.TipoAccionBDId,bd.ObjetoBD
from dbo.SolicitudBD bd 
where bd.ObjetoBD like '%'+@nombre+'%'
order by bd.SolicitudId desc