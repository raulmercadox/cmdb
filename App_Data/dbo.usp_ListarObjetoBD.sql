alter procedure dbo.usp_ListarObjetoBD
@proyectoid int,
@ambienteid int
as
select solbd.instanciaid,solbd.esquemaid,solbd.tipoobjetobdid,dbo.ufn_QuitarPunto(solbd.objetobd) objetobd,MAX(sollog.fechahora) fechahora
into #tabla1
from dbo.SolicitudBD solbd 
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio=1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid = @proyectoid and sol.ambienteid = @ambienteid
group by solbd.instanciaid,solbd.esquemaid,solbd.tipoobjetobdid,dbo.ufn_QuitarPunto(solbd.objetobd)

select a.instanciaid,a.esquemaid,solbd.tipoobjetobdid,a.objetobd,MAX(sollog.fechahora) fechahora
into #tabla2
from #tabla1 a
inner join dbo.Instancia inst on a.instanciaid = inst.instanciaAnteriorId
inner join dbo.Esquema esq on a.esquemaid = esq.id
inner join dbo.SolicitudBD solbd on inst.id = solbd.instanciaid and a.tipoobjetobdid = solbd.tipoobjetobdid and a.objetobd = dbo.ufn_QuitarPunto(solbd.objetobd)
inner join dbo.Esquema esqb on solbd.esquemaid = esqb.id and esq.nombre = esqb.nombre
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio = 1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid=@proyectoid
group by a.instanciaid,a.esquemaid,solbd.tipoobjetobdid,a.objetobd

select a.instanciaid,a.esquemaid,a.tipoobjetobdid,a.objetobd nombre,b.fechahora
into #tabla3
from #tabla1 a
left join #tabla2 b on a.instanciaid = b.instanciaid and a.esquemaid = b.esquemaid and a.tipoobjetobdid = b.tipoobjetobdid and a.objetobd = b.objetobd
inner join dbo.SolicitudBD c on a.instanciaid = c.instanciaid and a.esquemaid = c.esquemaid and a.tipoobjetobdid = c.tipoobjetobdid 
	and dbo.ufn_QuitarPunto(a.objetobd) = dbo.ufn_QuitarPunto(c.objetobd)
inner join dbo.Solicitudlog d on c.solicitudid = d.solicitudid and a.fechahora = d.fechahora
where b.instanciaid is null or a.fechahora > b.fechahora
order by a.instanciaid,a.esquemaid,a.tipoobjetobdid

select b.InstanciaId,b.EsquemaId,b.TipoObjetoBDId,b.TipoAccionBDId,a.nombre,b.informacionadicional,c.Id SolicitudId,MAX(e.FechaHora) fechahora
from #tabla3 a
inner join dbo.SolicitudBD b on a.InstanciaId = b.InstanciaId and a.EsquemaId = b.EsquemaId and a.TipoObjetoBDId = b.TipoObjetoBDId 
	and a.nombre = dbo.ufn_QuitarPunto(b.ObjetoBD)
inner join dbo.Solicitud c on b.SolicitudId = c.Id
inner join dbo.Estado d on c.Estado = d.Nombre and d.Satisfactorio = 1
inner join dbo.SolicitudLog e on c.Id = e.SolicitudId
where c.ProyectoId = @proyectoid
group by b.InstanciaId,b.EsquemaId,b.TipoObjetoBDId,b.TipoAccionBDId,a.nombre,b.informacionadicional,c.Id,a.fechahora
having isnull(a.fechahora,'1900-01-01') < MAX(e.FechaHora)
order by b.InstanciaId,b.EsquemaId,b.TipoObjetoBDId,a.nombre,7


