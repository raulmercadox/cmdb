create procedure dbo.usp_InsertarServidorUsuario
@ServidorId int,
@Nombre varchar(100),
@Clave varchar(100)
as
insert into dbo.ServidorUsuario (ServidorId,Nombre,Clave)
values (@ServidorId,@Nombre,@Clave)

select @@IDENTITY