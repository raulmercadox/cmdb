alter procedure [dbo].[usp_ObtenerAmbiente]
@id int
as
select id,nombre,Abreviatura,Final,Orden,FechaObligatoria,ApruebaCalidad,EnvioPrimeraSolicitud,ObservacionId
from dbo.Ambiente
where id = @id