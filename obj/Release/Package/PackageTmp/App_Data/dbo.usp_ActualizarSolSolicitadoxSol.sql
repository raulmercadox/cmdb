alter procedure dbo.usp_ActualizarSolSolicitadoxSol
@id int,
@estado varchar(50),
@copiara varchar(200)
as
update dbo.Solicitud set Estado = @Estado, CopiarA = @copiara
where id=@id

select @id