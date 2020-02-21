create procedure dbo.usp_ActualizarProyectoCorreo
@Id int,
@Correo varchar(100)
as
update dbo.ProyectoCorreo set Correo=@Correo where Id=@Id