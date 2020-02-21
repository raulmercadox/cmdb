alter procedure dbo.usp_ObtenerUsuario
@usuario varchar(30)
as
select id, usuario, correo, clave, administrador, operador, lector, CM, RM, Ejecutor,Test,Celular,Anexo,Skype
from dbo.Usuario
where usuario=@usuario