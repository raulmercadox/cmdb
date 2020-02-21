alter procedure [dbo].[usp_ActualizarArchivo10]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo10 = @archivo, NombreArchivo10 = @nombrearchivo, FechaArchivo10 = @fechaarchivo
where id=@id