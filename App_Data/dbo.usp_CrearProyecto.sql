alter procedure [dbo].[usp_CrearProyecto]
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
insert into dbo.Proyecto (codigo,nombre,pm,ptl,estado,FechaProd,ResponsableId,Mejora,impacto,tipoproyectoid,CodigoPresupuestal,CodigoAlterno) 
values (@codigo,@nombre,@pm,@ptl,@estado,@fechaprod,@responsableid,@mejora,@impacto,@tipoproyectoid,@codigopresupuestal,@codigoalterno)

select @@IDENTITY