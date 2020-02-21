create procedure dbo.usp_ActualizarDatosUsuario
@id int,
@correo varchar(100),
@celular varchar(20),
@anexo varchar(20),
@skype varchar(50)
as
update dbo.Usuario set correo = @correo, celular = @celular, anexo = @anexo, skype = @skype
where id = @id

select @id