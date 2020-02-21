alter procedure dbo.usp_ActualizarArea
@id int,
@nombre varchar(100),
@color varchar(50),
@abreviatura varchar(10)
as
update dbo.Area set nombre = @nombre, color=@color, abreviatura = @abreviatura
where id=@id
select @id
