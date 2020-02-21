alter procedure [dbo].[usp_ObtenerAmbientePorNombre]
@nombre varchar(50)
as
select id,nombre,Abreviatura,Final,Orden,FechaObligatoria,ApruebaCalidad,EnvioPrimeraSolicitud,ObservacionId
from dbo.Ambiente
where nombre = @nombre
order by nombre