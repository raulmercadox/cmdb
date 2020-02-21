alter procedure dbo.usp_CrearVentana
@desde datetime,
@hasta datetime = null
as
insert into dbo.Ventana(desde,hasta) values (@desde,@hasta)
select @@IDENTITY