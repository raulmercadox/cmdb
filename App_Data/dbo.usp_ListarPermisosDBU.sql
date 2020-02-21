alter procedure dbo.usp_ListarPermisosDBU
@proyectoid int,
@ambienteid int
as
select solbd.instanciaid,solbd.esquemaid,solbd.tipoobjetobdid,solbd.NombreObjeto,solbd.permisoDBU,MAX(sollog.fechahora) fechahora
into #tabla1
from dbo.SolicitudBDPermisoDBU solbd 
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio=1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid = @proyectoid and sol.ambienteid = @ambienteid
group by solbd.instanciaid,solbd.esquemaid,solbd.tipoobjetobdid,solbd.NombreObjeto,solbd.permisoDBU

select a.instanciaid,a.esquemaid,solbd.tipoobjetobdid,a.NombreObjeto,a.PermisoDBU,MAX(sollog.fechahora) fechahora
into #tabla2
from #tabla1 a
inner join dbo.Instancia inst on a.instanciaid = inst.instanciaAnteriorId
inner join dbo.Esquema esq on a.esquemaid = esq.id
inner join dbo.SolicitudBDPermisoDBU solbd on inst.id = solbd.instanciaid and a.tipoobjetobdid = solbd.tipoobjetobdid and a.NombreObjeto = solbd.NombreObjeto and a.PermisoDBU = solbd.PermisoDBU
inner join dbo.Esquema esqb on solbd.esquemaid = esqb.id and esq.nombre = esqb.nombre
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio = 1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid=@proyectoid
group by a.instanciaid,a.esquemaid,solbd.tipoobjetobdid,a.NombreObjeto,a.PermisoDBU

select a.instanciaid,a.esquemaid,a.tipoobjetobdid,a.NombreObjeto,a.PermisoDBU,b.fechahora
into #tabla3
from #tabla1 a
left join #tabla2 b on a.instanciaid = b.instanciaid and a.esquemaid = b.esquemaid and a.tipoobjetobdid = b.tipoobjetobdid and a.NombreObjeto = b.NombreObjeto and a.PermisoDBU = b.PermisoDBU
inner join dbo.SolicitudBDPermisoDBU c on a.instanciaid = c.instanciaid and a.esquemaid = c.esquemaid and a.tipoobjetobdid = c.tipoobjetobdid and a.NombreObjeto = c.NombreObjeto and a.permisoDBU = c.PermisoDBU
inner join dbo.Solicitudlog d on c.solicitudid = d.solicitudid and a.fechahora = d.fechahora
where b.instanciaid is null or a.fechahora > b.fechahora
order by a.instanciaid,a.esquemaid,a.tipoobjetobdid,a.NombreObjeto,a.PermisoDBU

select b.InstanciaId,b.EsquemaId,b.TipoObjetoBDId,b.NombreObjeto,b.PermisoDBU,b.[Select],b.[Insert],b.[Delete],b.[Update],b.[Execute],c.Id SolicitudId,MAX(e.FechaHora) fechahora
from #tabla3 a
inner join dbo.SolicitudBDPermisoDBU b on a.InstanciaId = b.InstanciaId and a.EsquemaId = b.EsquemaId and a.TipoObjetoBDId = b.TipoObjetoBDId
	and a.NombreObjeto = b.NombreObjeto and a.PermisoDBU = b.PermisoDBU
inner join dbo.Solicitud c on b.SolicitudId = c.Id
inner join dbo.Estado d on c.Estado = d.Nombre and d.Satisfactorio = 1
inner join dbo.SolicitudLog e on c.Id = e.SolicitudId
where c.ProyectoId = @proyectoid
group by b.InstanciaId,b.EsquemaId,b.TipoObjetoBDId,b.NombreObjeto,b.PermisoDBU,b.[Select],b.[Insert],b.[Delete],b.[Update],b.[Execute],c.Id,a.fechahora
having isnull(a.fechahora,'1900-01-01') < MAX(e.FechaHora)
order by b.InstanciaId,b.EsquemaId,b.TipoObjetoBDId,b.NombreObjeto,b.PermisoDBU,12