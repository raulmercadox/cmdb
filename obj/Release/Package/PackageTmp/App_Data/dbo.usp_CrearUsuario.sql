alter procedure dbo.usp_CrearUsuario
@usuario varchar(30),
@clave varchar(50),
@correo varchar(100),
@administrador bit,
@operador bit,
@lector bit,
@CM bit,
@RM bit,
@Ejecutor bit,
@Test bit,
@Celular varchar(20)='',
@Anexo varchar(20)='',
@Skype varchar(50)=''
as
insert into dbo.Usuario (usuario, clave, correo, Administrador, Operador, Lector, CM, RM, Ejecutor, Test, Celular, Anexo, Skype)
values (@usuario, @clave, @correo, @administrador, @operador, @lector, @CM, @RM, @Ejecutor,@Test,@Celular,@Anexo,@Skype)

select @@IDENTITY

