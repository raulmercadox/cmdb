alter procedure [dbo].[usp_ActualizarArchivo6]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo6 = @archivo, NombreArchivo6 = @nombrearchivo, FechaArchivo6 = @fechaarchivo
where id=@id