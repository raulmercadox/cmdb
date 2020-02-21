alter procedure [dbo].[usp_ActualizarAmbiente]
@id int,
@nombre varchar(50),
@abreviatura varchar(10),
@final bit = 0,
@orden int=0,
@fechaobligatoria bit,
@apruebacalidad bit = 0,
@envioprimerasolicitud bit = 0,
@observacionid int
as
update dbo.Ambiente set nombre=@nombre,Abreviatura=@abreviatura,final=@final,Orden=@orden,FechaObligatoria=@fechaobligatoria,ApruebaCalidad = @ApruebaCalidad,
EnvioPrimeraSolicitud = @envioprimerasolicitud,observacionid=case when @observacionid=0 then null else @observacionid end
where id=@id

select @id