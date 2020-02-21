alter procedure dbo.usp_ListarCalendarioPases
@ambienteid int,
@fechadesde datetime,
@fechahasta datetime
as
select p.Id ProyectoId,p.Codigo ProyectoCodigo,p.Nombre ProyectoNombre,pa.FechaPase,'Programado' tipo
into #tabla1
from dbo.Proyecto p 
inner join dbo.ProyectoAmbiente pa on p.Id = pa.ProyectoId
where pa.AmbienteId = @ambienteid and convert(varchar, pa.FechaPase, 112) between convert(varchar, @fechadesde, 112) and convert(varchar, @fechahasta, 112)

select p.Id ProyectoId,p.Codigo ProyectoCodigo,p.Nombre ProyectoNombre,min(sl.FechaHora) FechaPase
into #tabla2
from dbo.Proyecto p
inner join dbo.Solicitud s on s.ProyectoId = p.Id
inner join dbo.Ambiente a on s.AmbienteId = a.Id
inner join dbo.SolicitudLog sl on s.Id = sl.SolicitudId
inner join dbo.Estado e on sl.Estado = e.Nombre
where e.Satisfactorio = 1 and
convert(varchar, sl.FechaHora, 112) between convert(varchar, @fechadesde, 112) and convert(varchar, @fechahasta, 112) and
a.Id = @ambienteid
group by p.Id,p.Codigo,p.Nombre

select p.Id,MIN(sl.FechaHora) fechahora
into #tabla3
from #tabla2 t2 
inner join dbo.Proyecto p on t2.ProyectoId = p.Id
inner join dbo.Solicitud s on p.Id = s.ProyectoId
inner join dbo.Ambiente a on s.AmbienteId = a.Id
inner join dbo.SolicitudLog sl on s.Id = sl.SolicitudId
inner join dbo.Estado e on sl.Estado = e.Nombre
where e.satisfactorio = 1 and a.Id = @ambienteid
group by p.Id

select a.ProyectoId,a.ProyectoCodigo,a.ProyectoNombre,a.FechaPase
into #result
from #tabla2 a
inner join #tabla3 b on a.ProyectoId = b.Id and a.FechaPase = b.fechahora

select a.ProyectoId,a.ProyectoCodigo,a.ProyectoNombre,a.FechaPase,a.Tipo
from #tabla1 a
union
select b.ProyectoId,b.ProyectoCodigo,b.ProyectoNombre,b.FechaPase,'Ejecutado' Tipo
from #result b