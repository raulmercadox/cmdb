create procedure [dbo].[usp_InsertarTipoProyecto]
@nombre varchar(50)
as
insert into dbo.TipoProyecto (Nombre) values (@nombre)

select @@IDENTITY