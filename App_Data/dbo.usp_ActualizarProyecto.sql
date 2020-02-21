alter procedure [dbo].[usp_ActualizarProyecto]
@id int,
@codigo varchar(30),
@nombre varchar(100),
@pm varchar(50),
@ptl varchar(50),
@estado char(1),
@fechaprod datetime = null,
@responsableid int = null,
@mejora bit,
@impacto varchar(max),
@tipoproyectoid int = null,
@codigopresupuestal varchar(10) = '',
@codigoalterno varchar(30) = ''
as
update dbo.Proyecto set codigo=@codigo, nombre=@nombre, pm=@pm, ptl=@ptl, estado=@estado, FechaProd = @fechaprod, ResponsableId = @responsableid,
Mejora = @mejora, Impacto = @impacto, TipoProyectoId = @tipoproyectoid, CodigoPresupuestal = @codigopresupuestal, CodigoAlterno = @codigoalterno
where id=@id

select @id