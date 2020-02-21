CREATE procedure [dbo].[usp_ActualizarResponsable]
@id int,
@nombre varchar(50)
as
update dbo.Responsable set nombre=@nombre where id=@id

select @id