alter table dbo.Usuario
add Celular varchar(20) not null constraint DF_Usuario_Celular default ''

alter table dbo.Usuario
add Anexo varchar(20) not null constraint DF_Usuario_Anexo default ''

alter table dbo.Usuario
add Skype varchar(50) not null constraint DF_Usuario_Skype default ''