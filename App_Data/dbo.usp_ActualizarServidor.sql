alter procedure [dbo].[usp_ActualizarServidor]
@id int,
@nombreservidor varchar(50),
@ipservidor varchar(15),
@ambienteid int,
@descripcion varchar(max)=''
as
update dbo.Servidor set nombre = @nombreservidor, ip=@ipservidor, AmbienteId = case when @ambienteid = 0 then null else @ambienteid end,
Descripcion = @descripcion
where id = @id

select @id