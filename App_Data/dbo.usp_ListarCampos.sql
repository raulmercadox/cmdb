alter procedure dbo.usp_ListarCampos
@proyectoid int,
@ambienteid int
as
select solbd.instanciaid,solbd.esquemaid,solbd.nombreTabla,solbd.NombreColumna,MAX(sollog.fechahora) fechahora
into #tabla1
from dbo.SolicitudBDCampo solbd 
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio=1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid = @proyectoid and sol.ambienteid = @ambienteid
group by solbd.instanciaid,solbd.esquemaid,solbd.NombreTabla,solbd.NombreColumna

select a.instanciaid,a.esquemaid,solbd.NombreTabla,a.NombreColumna,MAX(sollog.fechahora) fechahora
into #tabla2
from #tabla1 a
inner join dbo.Instancia inst on a.instanciaid = inst.instanciaAnteriorId
inner join dbo.Esquema esq on a.esquemaid = esq.id
inner join dbo.SolicitudBDCampo solbd on inst.id = solbd.instanciaid and a.NombreTabla = solbd.NombreTabla and a.NombreColumna = solbd.NombreColumna
inner join dbo.Esquema esqb on solbd.esquemaid = esqb.id and esq.nombre = esqb.nombre
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio = 1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid=@proyectoid
group by a.instanciaid,a.esquemaid,solbd.NombreTabla,a.NombreColumna

select a.instanciaid,a.esquemaid,a.NombreTabla,a.NombreColumna,b.fechahora
into #tabla3
from #tabla1 a
left join #tabla2 b on a.instanciaid = b.instanciaid and a.esquemaid = b.esquemaid and a.NombreTabla = b.NombreTabla and a.NombreColumna = b.NombreColumna
inner join dbo.SolicitudBDCampo c on a.instanciaid = c.instanciaid and a.esquemaid = c.esquemaid and a.NombreTabla = c.NombreTabla and a.NombreColumna = c.NombreColumna
inner join dbo.Solicitudlog d on c.solicitudid = d.solicitudid and a.fechahora = d.fechahora
where b.instanciaid is null or a.fechahora > b.fechahora
order by a.instanciaid,a.esquemaid,a.NombreTabla,a.NombreColumna

select b.InstanciaId,b.EsquemaId,b.TipoAccionBDId,a.NombreTabla,a.NombreColumna,b.Tipo,c.Id SolicitudId,MAX(e.FechaHora) fechahora
from #tabla3 a
inner join dbo.SolicitudBDCampo b on a.InstanciaId = b.InstanciaId and a.EsquemaId = b.EsquemaId and a.NombreTabla = b.NombreTabla 
	and a.NombreColumna = b.NombreColumna
inner join dbo.Solicitud c on b.SolicitudId = c.Id
inner join dbo.Estado d on c.Estado = d.Nombre and d.Satisfactorio = 1
inner join dbo.SolicitudLog e on c.Id = e.SolicitudId
where c.ProyectoId = @proyectoid
group by b.InstanciaId,b.EsquemaId,b.TipoAccionBDId,a.NombreTabla,a.NombreColumna,b.Tipo,c.Id,a.fechahora
having isnull(a.fechahora,'1900-01-01') < MAX(e.FechaHora)
order by b.InstanciaId,b.EsquemaId,a.NombreTabla,a.NombreColumna,7


