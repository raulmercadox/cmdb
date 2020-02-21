create procedure dbo.usp_ActualizarServidorUsuario
@Id int,
@Nombre varchar(100),
@Clave varchar(100)
as
update dbo.ServidorUsuario set Nombre=@Nombre,Clave=@Clave where Id=@Id