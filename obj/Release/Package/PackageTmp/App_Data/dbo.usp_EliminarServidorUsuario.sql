create procedure dbo.usp_EliminarServidorUsuario
@Id int
as
delete from dbo.ServidorUsuario where Id=@Id