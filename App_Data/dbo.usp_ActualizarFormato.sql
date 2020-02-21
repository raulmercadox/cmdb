alter procedure dbo.usp_ActualizarFormato
@id int,
@nombre varchar(50),
@descripcion varchar(100),
@codigo varchar(20),
@version varchar(30),
@carpetabase varchar(50)
as
update dbo.Formato set Nombre = @nombre , Descripcion = @descripcion, Codigo=@codigo, [version]=@version, CarpetaBase=@carpetabase
where id=@id

select @id