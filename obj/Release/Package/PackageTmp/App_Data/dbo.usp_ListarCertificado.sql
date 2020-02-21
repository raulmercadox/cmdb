create procedure dbo.usp_ListarCertificado
@proyectoid int,
@ambienteid int
as
select id,proyectoid,ambienteid,usuarioid,fechahora,certificado
from dbo.ProyectoCertificado
where proyectoid=@proyectoid and ambienteid=@ambienteid
order by fechahora