alter procedure dbo.usp_ListarReversion
as
-- Lista de proyectos que tienen una fecha de reversion vencida
select proy.id proyectoid,max(sol.fechareversion) fechareversion
into #tabla1
from dbo.Solicitud sol 
inner join dbo.Proyecto proy on sol.ProyectoId = proy.Id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio = 1
where proy.Mejora=1 and sol.FechaReversion is not null and sol.FechaReversion <= GETDATE()
group by proy.id
order by 1,2

-- lista de proyecto cuyas solicitudes tienen marca de reversion
select proy.id proyectoid,MAX(sollog.fechahora) fechahora
into #tabla2
from dbo.Solicitud sol
inner join dbo.Proyecto proy on sol.ProyectoId = proy.Id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio = 1
inner join dbo.SolicitudLog sollog on sol.Id = sollog.SolicitudId
where proy.Mejora = 1 and sol.Reversion = 1
group by proy.Id

select a.proyectoid,proy.codigo,proy.nombre
from #tabla1 a
inner join Proyecto proy on a.proyectoid = proy.Id
left join #tabla2 b on a.proyectoid = b.proyectoid
where b.proyectoid is null or a.fechareversion > b.fechahora and a.fechareversion <= GETDATE()
order by proy.Codigo