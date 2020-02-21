alter procedure [dbo].[usp_ActualizarArchivo2]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo2 = @archivo, NombreArchivo2 = @nombrearchivo, FechaArchivo2 = @fechaarchivo
where id=@id