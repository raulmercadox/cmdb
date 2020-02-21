alter procedure dbo.usp_CrearFormato
@nombre varchar(50),
@descripcion varchar(100),
@codigo varchar(20),
@version varchar(30),
@carpetabase varchar(50)
as
insert into dbo.Formato(Nombre,Descripcion,Codigo,[Version],CarpetaBase) values (@nombre,@descripcion,@codigo,@version,@carpetabase)

select @@identity