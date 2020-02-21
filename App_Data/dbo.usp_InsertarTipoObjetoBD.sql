alter procedure dbo.usp_InsertarTipoObjetoBD
@nombre varchar(50),
@extension varchar(20)
as
insert into dbo.TipoObjetoBD (Nombre,Extension) values (@nombre,@extension)

select @@IDENTITY