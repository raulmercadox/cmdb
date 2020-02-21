alter procedure dbo.usp_ActualizarVentana
@id int,
@desde datetime,
@hasta datetime = null
as
update dbo.Ventana set desde=@desde, hasta=@hasta where id=@id

select @id