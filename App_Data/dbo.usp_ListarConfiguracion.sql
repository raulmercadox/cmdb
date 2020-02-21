CREATE procedure dbo.usp_ListarConfiguracion
@proyectoid int,
@ambienteid int
as
select solbd.instanciaid,solbd.esquemaid,solbd.tabla,solbd.comentario,solbd.archivo,solbd.tipo,MAX(sollog.fechahora) fechahora
into #tabla1
from dbo.SolicitudBDConfiguracion solbd 
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio=1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid = @proyectoid and sol.ambienteid = @ambienteid
group by solbd.instanciaid,solbd.esquemaid,solbd.tabla,solbd.comentario,solbd.archivo,solbd.tipo

select a.instanciaid,a.esquemaid,a.tabla,a.comentario,a.archivo,a.tipo,MAX(sollog.fechahora) fechahora
into #tabla2
from #tabla1 a
inner join dbo.Instancia inst on a.instanciaid = inst.instanciaAnteriorId
inner join dbo.Esquema esq on a.esquemaid = esq.id
inner join dbo.SolicitudBDConfiguracion solbd on inst.id = solbd.instanciaid and a.tabla = solbd.tabla and a.comentario = solbd.comentario and a.archivo = solbd.archivo and 
	a.tipo = solbd.tipo
inner join dbo.Esquema esqb on solbd.esquemaid = esqb.id and esq.nombre = esqb.nombre
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio = 1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid=@proyectoid
group by a.instanciaid,a.esquemaid,a.tabla,a.comentario,a.archivo,a.tipo

select distinct a.instanciaid,a.esquemaid,a.tabla,a.comentario,a.archivo,a.tipo,c.solicitudid
from #tabla1 a
left join #tabla2 b on a.instanciaid = b.instanciaid and a.esquemaid = b.esquemaid and a.tabla = b.tabla and a.comentario = b.Comentario and a.archivo = b.archivo and 
	a.tipo = b.tipo
inner join dbo.SolicitudBDConfiguracion c on a.instanciaid = c.instanciaid and a.esquemaid = c.esquemaid and a.tabla = c.tabla and a.comentario = c.comentario 
	and a.archivo = c.archivo and a.tipo = c.tipo
inner join dbo.Solicitudlog d on c.solicitudid = d.solicitudid and a.fechahora = d.fechahora
where b.instanciaid is null or a.fechahora > b.fechahora
order by a.instanciaid,a.esquemaid,a.tabla,a.comentario,a.archivo,a.tipo,c.solicitudid

