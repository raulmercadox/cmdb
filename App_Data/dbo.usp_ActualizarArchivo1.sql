alter procedure [dbo].[usp_ActualizarArchivo1]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo1 = @archivo, NombreArchivo1 = @nombrearchivo, FechaArchivo1 = @fechaarchivo
where id=@id