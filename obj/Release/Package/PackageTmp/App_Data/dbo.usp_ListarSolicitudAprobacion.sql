alter procedure dbo.usp_ListarSolicitudAprobacion
@solicitudid int
as
select sa.id,sa.nombrearchivo,a.Id AreaId,a.Nombre AreaNombre, sa.FechaHora, sa.ContentType,a.Color
from dbo.solicitudaprobacion sa
left join dbo.Area a on sa.AreaId = a.id
where sa.solicitudid = @solicitudid
order by id
