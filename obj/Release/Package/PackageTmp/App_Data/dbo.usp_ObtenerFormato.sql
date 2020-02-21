alter procedure dbo.usp_ObtenerFormato
@id int
as
select Id,Nombre,Descripcion,Codigo,[Version],CarpetaBase from dbo.Formato
where id=@id