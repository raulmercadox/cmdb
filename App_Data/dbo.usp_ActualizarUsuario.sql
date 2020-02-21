alter procedure dbo.usp_ActualizarUsuario
@id int,
@usuario varchar(30),
@correo varchar(100),
@administrador bit,
@operador bit,
@lector bit,
@cm bit,
@rm bit,
@ejecutor bit,
@test bit,
@celular varchar(20)='',
@anexo varchar(20)='',
@skype varchar(50)=''
as
update dbo.Usuario set usuario = @usuario, correo = @correo, administrador = @administrador, operador = @operador, lector = @lector, cm = @cm, rm = @rm,
ejecutor = @ejecutor, Test=@test, Celular=@celular, Anexo=@anexo, Skype=@skype
where id = @id

select @id
