alter procedure [dbo].[usp_ActualizarArchivo8]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo8 = @archivo, NombreArchivo8 = @nombrearchivo, FechaArchivo8 = @fechaarchivo
where id=@id