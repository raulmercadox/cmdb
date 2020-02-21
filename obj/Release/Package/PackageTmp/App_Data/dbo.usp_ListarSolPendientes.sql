create procedure dbo.usp_ListarSolPendientes
@proyectoid int
as
select a.Abreviatura,a.Orden,COUNT(*) total
into #tabla1
from dbo.Solicitud s
inner join dbo.Estado e on s.Estado = e.Nombre
inner join dbo.Ambiente a on s.AmbienteId = a.Id
where s.ProyectoId = @proyectoid
and e.Pendiente=1
group by a.Abreviatura,a.Orden
order by a.Orden

select a.Abreviatura,a.Orden
into #tabla2
from dbo.Ambiente a

select a.Abreviatura,ISNULL(b.total,0) total
from #tabla2 a left join #tabla1 b
on a.Abreviatura = b.Abreviatura
order by a.Orden