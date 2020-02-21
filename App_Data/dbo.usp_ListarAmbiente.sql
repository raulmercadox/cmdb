alter procedure [dbo].[usp_ListarAmbiente]
@nombre varchar(50),
@fechaobligatoria bit = 0,
@apruebacalidad bit = 0,
@envioprimerasolicitud bit = 0
as
select id, nombre, Abreviatura,Final,Orden,FechaObligatoria,ApruebaCalidad,EnvioPrimeraSolicitud,ObservacionId
from dbo.Ambiente
where nombre like '%' + @nombre + '%'
and fechaobligatoria = case when @fechaobligatoria=0 then fechaobligatoria else @fechaobligatoria end
and apruebacalidad = case when @apruebacalidad=0 then apruebacalidad else @apruebacalidad end
and EnvioPrimeraSolicitud = case when @envioprimerasolicitud=0 then EnvioPrimeraSolicitud else @envioprimerasolicitud end
order by Orden