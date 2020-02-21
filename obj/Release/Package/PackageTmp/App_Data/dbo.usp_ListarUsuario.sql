alter procedure dbo.usp_ListarUsuario
@usuario varchar(30),
@correo varchar(100),
@administrador bit,
@operador bit,
@lector bit,
@CM bit,
@RM bit,
@Ejecutor bit,
@test bit,
@celular varchar(20)='',
@anexo varchar(20)='',
@skype varchar(50)=''
as
select id, Usuario, Clave, Correo, Administrador, Operador, Lector, CM, RM, Ejecutor, Test,Celular,Anexo,Skype
from dbo.Usuario
where usuario like case when @usuario='' then '%%' else '%'+@usuario+'%' end
and correo like case when @correo='' then '%%' else '%'+@correo+'%' end
and administrador = case when @administrador=0 then administrador else @administrador end
and operador = case when @operador=0 then operador else @operador end
and lector= case when @lector=0 then lector else @lector end
and CM= case when @CM=0 then cm else @CM end
and RM= case when @RM=0 then rm else @RM end
and Ejecutor = case when @Ejecutor=0 then ejecutor else @Ejecutor end
and Test = case when @test = 0 then Test else @test end
and Celular like case when @celular='' then '%%' else '%'+@celular+'%' end
and Anexo like case when @anexo='' then '%%' else '%'+@anexo+'%' end
and Skype like case when @skype='' then '%%' else '%'+@skype+'%' end
order by Usuario

