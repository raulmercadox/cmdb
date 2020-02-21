alter procedure dbo.usp_ObtenerArchivoAprobacionPorNombre
@solicitudid int,
@nombre varchar(100)
as
select Id,SolicitudId,NombreArchivo,Contenido,FechaHora,ContentType
from dbo.SolicitudAprobacion
where SolicitudId=@solicitudid and NombreArchivo=@nombre