create procedure dbo.usp_InsertarProyectoCorreo
@ProyectoId int,
@Correo varchar(100)
as
insert into dbo.ProyectoCorreo(ProyectoId,Correo)
values (@ProyectoId,@Correo)

select @@IDENTITY