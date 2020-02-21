alter procedure dbo.usp_ObtenerUsuarioPorid
@id int
as
select id, usuario, correo, clave, administrador, operador, lector, CM, RM, Ejecutor,Test,Celular,Anexo,Skype
from dbo.Usuario
where id=@id