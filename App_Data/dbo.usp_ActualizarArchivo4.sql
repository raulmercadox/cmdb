alter procedure [dbo].[usp_ActualizarArchivo4]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo4 = @archivo, NombreArchivo4 = @nombrearchivo, FechaArchivo4 = @fechaarchivo
where id=@id