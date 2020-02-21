alter procedure [dbo].[usp_ActualizarArchivo9]
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechaarchivo datetime = null
as
update dbo.Solicitud set Archivo9 = @archivo, NombreArchivo9 = @nombrearchivo, FechaArchivo9 = @fechaarchivo
where id=@id