alter procedure [dbo].[usp_ListarProyecto]
@codigo varchar(30),
@nombre varchar(100),
@pm varchar(50),
@ptl varchar(50),
@estado char(1),
@responsableid int,
@mejora bit,
@impacto varchar(50),
@tipoproyectoid int,
@codigopresupuestal varchar(10) = '',
@codigoalterno varchar(30) = ''
as
select id, codigo, nombre, pm, ptl, estado, FechaProd, ResponsableId,Mejora,impacto,TipoProyectoId,CodigoPresupuestal,CodigoAlterno
from dbo.Proyecto
where codigo like case when @codigo='' then '%%' else '%'+@codigo+'%' end
and nombre like case when @nombre='' then '%%' else '%'+@nombre+'%' end
and pm like case when @pm='' then '%%' else '%'+@pm+'%' end
and ptl like case when @ptl='' then '%%' else '%'+@ptl+'%' end 
and estado=case when @estado='A' or @estado=' ' then estado else @estado end
and isnull(ResponsableId,0)=case when @responsableid=0 then isnull(ResponsableId,0) else @responsableid end
and Mejora = case when @Mejora = 0 then Mejora else @mejora end
and Impacto like case when @impacto='' then '%%' else '%'+@impacto+'%' end
and ISNULL(tipoproyectoid,0)=case when @tipoproyectoid=0 then ISNULL(tipoproyectoid,0) else @tipoproyectoid end
and CodigoPresupuestal like case when @codigopresupuestal='' then '%%' else '%'+@codigopresupuestal+'%' end
and CodigoAlterno like case when @codigoalterno='' then '%%' else '%'+@codigoalterno+'%' end
order by codigo