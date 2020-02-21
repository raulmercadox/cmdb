alter procedure dbo.usp_ObtenerArchivoAprobacion
@id int
as
select Contenido,NombreArchivo,FechaHora,ContentType
from dbo.SolicitudAprobacion
where id = @id