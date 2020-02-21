create procedure dbo.usp_InsertarProyectoAmbiente
@proyectoid int,
@ambienteid int,
@fechapase datetime
as
insert into dbo.ProyectoAmbiente (proyectoid,ambienteid,fechapase)
values (@proyectoid,@ambienteid,@fechapase)

select @@identity