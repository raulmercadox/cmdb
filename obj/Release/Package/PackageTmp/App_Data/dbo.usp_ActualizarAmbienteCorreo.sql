create procedure dbo.usp_ActualizarAmbienteCorreo
@id int,
@ambienteid int,
@correo varchar(100)
as
update dbo.AmbienteCorreo set correo=@correo where ID=@id