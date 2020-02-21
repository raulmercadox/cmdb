alter procedure [dbo].[usp_ActualizarArchivo7]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo7 = @archivo, NombreArchivo7 = @nombrearchivo, FechaArchivo7 = @fechaarchivo
where id=@id