alter procedure [dbo].[usp_ActualizarArchivo5]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo5 = @archivo, NombreArchivo5 = @nombrearchivo, FechaArchivo5 = @fechaarchivo
where id=@id