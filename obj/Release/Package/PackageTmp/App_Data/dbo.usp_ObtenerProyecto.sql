alter procedure [dbo].[usp_ObtenerProyecto]
@codigo varchar(30)
as
select id,codigo,nombre,pm,ptl,estado,FechaProd,ResponsableId,Mejora,Impacto,TipoProyectoId,CodigoPresupuestal,CodigoAlterno
from dbo.Proyecto
where Codigo = @codigo