create procedure dbo.usp_ListarJob
@proyectoid int,
@ambienteid int
as
select solbd.instanciaid,solbd.esquemaid,solbd.tipo,solbd.nombre,solbd.ejecucioninicial,solbd.intervalo,solbd.informacionadicional,MAX(sollog.fechahora) fechahora
into #tabla1
from dbo.SolicitudBDJob solbd 
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio=1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid = @proyectoid and sol.ambienteid = @ambienteid
group by solbd.instanciaid,solbd.esquemaid,solbd.tipo,solbd.nombre,solbd.ejecucioninicial,solbd.intervalo,solbd.informacionadicional

select a.instanciaid,a.esquemaid,a.tipo,a.nombre,a.ejecucioninicial,a.intervalo,a.informacionadicional,MAX(sollog.fechahora) fechahora
into #tabla2
from #tabla1 a
inner join dbo.Instancia inst on a.instanciaid = inst.instanciaAnteriorId
inner join dbo.Esquema esq on a.esquemaid = esq.id
inner join dbo.SolicitudBDJob solbd on inst.id = solbd.instanciaid and a.tipo = solbd.tipo and a.nombre = solbd.nombre and a.ejecucioninicial = solbd.ejecucioninicial and 
	a.intervalo = solbd.intervalo and a.informacionadicional = solbd.informacionadicional
inner join dbo.Esquema esqb on solbd.esquemaid = esqb.id and esq.nombre = esqb.nombre
inner join dbo.Solicitud sol on solbd.solicitudid = sol.id
inner join dbo.Estado est on sol.Estado = est.Nombre and est.Satisfactorio = 1
inner join dbo.SolicitudLog sollog on sol.id = sollog.solicitudid
where sol.proyectoid=@proyectoid
group by a.instanciaid,a.esquemaid,a.tipo,a.nombre,a.ejecucioninicial,a.intervalo,a.informacionadicional

select distinct a.instanciaid,a.esquemaid,a.tipo,a.nombre,a.ejecucioninicial,a.intervalo,a.informacionadicional,c.solicitudid
from #tabla1 a
left join #tabla2 b on a.instanciaid = b.instanciaid and a.esquemaid = b.esquemaid and a.tipo = b.tipo and a.nombre = b.nombre and a.ejecucioninicial = b.ejecucioninicial and 
	a.intervalo = b.intervalo and a.informacionadicional = b.informacionadicional
inner join dbo.SolicitudBDJob c on a.instanciaid = c.instanciaid and a.esquemaid = c.esquemaid and a.tipo = c.tipo and a.nombre = c.nombre and a.ejecucioninicial = c.ejecucioninicial and
	a.intervalo = c.intervalo and a.informacionadicional = c.informacionadicional
inner join dbo.Solicitudlog d on c.solicitudid = d.solicitudid and a.fechahora = d.fechahora
where b.instanciaid is null or a.fechahora > b.fechahora
order by a.instanciaid,a.esquemaid,a.tipo,a.nombre,a.ejecucioninicial,a.intervalo,a.informacionadicional,c.solicitudid