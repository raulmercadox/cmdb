alter procedure [dbo].[usp_ListarLog]
@SolicitudId int
as
select Id,SolicitudId,Accion,Estado,UsuarioId,FechaHora,Comentario,NombreArchivo,ObservacionId
from dbo.SolicitudLog
where SolicitudId=@SolicitudId
order by FechaHora desc