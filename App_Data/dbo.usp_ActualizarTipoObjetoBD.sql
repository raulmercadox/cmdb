alter procedure dbo.usp_ActualizarTipoObjetoBD
@id int,
@nombre varchar(50),
@extension varchar(20)
as
update dbo.TipoObjetoBD set Nombre = @nombre ,Extension=@extension
where id=@id
select @id