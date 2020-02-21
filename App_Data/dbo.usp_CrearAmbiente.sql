alter procedure [dbo].[usp_CrearAmbiente]
@nombre varchar(50),
@abreviatura varchar(10),
@final bit = 0,
@orden int=0,
@fechaobligatoria bit,
@apruebacalidad bit=0,
@envioprimerasolicitud bit=0,
@observacionid int
as
insert into dbo.Ambiente (nombre,Abreviatura,final,orden,FechaObligatoria,ApruebaCalidad,EnvioPrimeraSolicitud,ObservacionId) 
values (@nombre,@abreviatura,@final,@orden,@fechaobligatoria,@apruebacalidad,@envioprimerasolicitud,case when @observacionid=0 then null else @observacionid end)

select @@identity