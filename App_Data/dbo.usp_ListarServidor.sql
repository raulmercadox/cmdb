alter procedure [dbo].[usp_ListarServidor]
@ipservidor varchar(15),
@nombreservidor varchar(50),
@ambienteid int,
@descripcion varchar(max)=''
as
select s.id, s.Ip, s.nombre, isnull(a.id,0) ambienteid, isnull(a.nombre,'') ambientenombre,descripcion
from dbo.Servidor s left join dbo.Ambiente a on s.AmbienteId = a.Id
where s.IP like case when @ipservidor='' then '%%' else '%'+@ipservidor+'%' end
and s.Nombre like case when @nombreservidor='' then '%%' else '%'+@nombreservidor+'%' end
and isnull(s.ambienteid,0)  = case when @ambienteid = 0 then isnull(s.ambienteid,0) else @ambienteid end
and s.Descripcion like case when @descripcion='' then '%%' else '%'+@descripcion+'%' end
order by s.IP