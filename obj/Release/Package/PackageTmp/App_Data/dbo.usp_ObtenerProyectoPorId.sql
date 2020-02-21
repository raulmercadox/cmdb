alter procedure [dbo].[usp_ObtenerProyectoPorId]
@id int
as
select id,codigo,nombre,pm,ptl,estado,FechaProd,ResponsableId,Mejora,Impacto,TipoProyectoId,CodigoPresupuestal,CodigoAlterno
from dbo.Proyecto
where Id = @id