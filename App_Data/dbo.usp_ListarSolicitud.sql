alter procedure dbo.usp_ListarSolicitud
@codigo varchar(10),
@proyectoid int,
@ambienteid int,
@analistades varchar(100),
@analistatest varchar(100),
@emergente bit,
@razonemergente varchar(200),
@fechaDesde date = null,
@fechaHasta date = null,
@rfc varchar(10) = '',
@solicitante varchar(30) = '',
@principal bit = 0,
@adicional bit = 0,
@todos bit = 1,
@fechaEjecucionDesde Datetime = null,
@fechaEjecucionHasta Datetime = null
as
select top 100 s.Id, s.ProyectoId, s.FechaCreacion, s.UsuarioId, s.AnalistaDes, s.AnalistaTestProd, s.CopiarA, s.AmbienteId, s.NombreArchivo1, s.NombreArchivo2,
s.NombreArchivo3, s.NombreArchivo4, s.NombreArchivo5, s.NombreArchivo6, s.NombreArchivo7, s.NombreArchivo8, s.NombreArchivo9, s.NombreArchivo10,
s.Emergente, s.RazonEmergente, s.Estado, s.Area1, s.Area2, s.Area3, s.Area4, s.Area5, s.Area6, s.Area7, s.Area8, s.Area9, s.Area10,s.FechaReversion,s.Reversion,s.Principal,S.RFC,
s.FechaEjecucion,s.Adicional,s.Estado1,s.Estado2,s.Estado3,s.Estado4,s.Estado5,s.Estado6,s.Estado7,s.Estado8,s.Estado9,s.Estado10,
s.Comentario1,s.Comentario2,s.Comentario3,s.Comentario4,s.Comentario5,s.Comentario6,s.Comentario7,s.Comentario8,s.Comentario9,s.Comentario10,e.pendiente,e.satisfactorio
from dbo.Solicitud s inner join dbo.Usuario u on s.UsuarioId = u.Id
inner join dbo.Estado e on s.Estado = e.Nombre
where 'S'+REPLACE(STR(s.id, 6), SPACE(1), '0') like case when ltrim(rtrim(@codigo))='' then '%%' else '%'+@codigo+'%' end
and s.ProyectoId = case when @proyectoid=0 then s.ProyectoId else @proyectoid end
and s.AmbienteId = case when @ambienteid=0 then s.AmbienteId else @ambienteid end
and s.AnalistaDes like case when ltrim(rtrim(@analistades))='' then '%%' else '%'+@analistades+'%' end
and s.AnalistaTestProd like case when ltrim(rtrim(@analistatest))='' then '%%' else '%'+@analistatest+'%' end
and s.Rfc like case when LTRIM(rtrim(@rfc))='' then '%%' else '%'+@rfc+'%' end
and u.Usuario like case when LTRIM(rtrim(@solicitante)) = '' then '%%' else '%'+@solicitante+'%' end
and s.Emergente = case when @emergente=0 then s.Emergente else @emergente end
and s.Principal = case when @principal=0 then s.Principal else @principal end
and s.Adicional = case when @adicional=0 then s.Adicional else @adicional end
and s.RazonEmergente like case when ltrim(rtrim(@razonemergente))='' then '%%' else '%'+@razonemergente+'%' end
and 
REPLACE(STR(year(s.FechaCreacion), 4), SPACE(1), '0')+REPLACE(STR(month(s.FechaCreacion), 2), SPACE(1), '0')+REPLACE(STR(day(s.FechaCreacion), 2), SPACE(1), '0') >= 
case when @fechaDesde IS null 
	then REPLACE(STR(year(s.FechaCreacion), 4), SPACE(1), '0')+REPLACE(STR(month(s.FechaCreacion), 2), SPACE(1), '0')+REPLACE(STR(day(s.FechaCreacion), 2), SPACE(1), '0')
	else REPLACE(STR(year(@fechadesde), 4), SPACE(1), '0')+REPLACE(STR(month(@fechadesde), 2), SPACE(1), '0')+REPLACE(STR(day(@fechadesde), 2), SPACE(1), '0') 
end
and
REPLACE(STR(year(s.FechaCreacion), 4), SPACE(1), '0')+REPLACE(STR(month(s.FechaCreacion), 2), SPACE(1), '0')+REPLACE(STR(day(s.FechaCreacion), 2), SPACE(1), '0') <= 
case when @fechaHasta IS null 
	then REPLACE(STR(year(s.FechaCreacion), 4), SPACE(1), '0')+REPLACE(STR(month(s.FechaCreacion), 2), SPACE(1), '0')+REPLACE(STR(day(s.FechaCreacion), 2), SPACE(1), '0')
	else REPLACE(STR(year(@fechahasta), 4), SPACE(1), '0')+REPLACE(STR(month(@fechahasta), 2), SPACE(1), '0')+REPLACE(STR(day(@fechahasta), 2), SPACE(1), '0') 
end
and 
(
(e.Pendiente = case when @todos=1 then e.Pendiente else 1 end)
or 
(e.Satisfactorio = case when @todos=1 then e.Satisfactorio else 1 end)
)
and
convert(varchar,s.FechaEjecucion,112) between 
	case when @fechaEjecucionDesde is null then convert(varchar,s.FechaEjecucion,112) else convert(varchar,@fechaEjecucionDesde,112) end
and case when @fechaEjecucionHasta is null then convert(varchar,s.FechaEjecucion,112) else convert(varchar,@fechaEjecucionHasta,112) end
order by s.Id desc