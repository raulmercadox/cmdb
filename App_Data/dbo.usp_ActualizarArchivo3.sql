alter procedure [dbo].[usp_ActualizarArchivo3]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo3 = @archivo, NombreArchivo3 = @nombrearchivo, FechaArchivo3 = @fechaarchivo
where id=@id