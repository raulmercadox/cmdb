create procedure [dbo].[usp_ActualizarTipoProyecto]
@id int,
@nombre varchar(50)
as
update dbo.TipoProyecto set Nombre = @nombre 
where id=@id
select @id

