CREATE procedure [dbo].[usp_ObtenerArchivoLog]
@id int
as
select Archivo,NombreArchivo
from dbo.SolicitudLog
where id = @id