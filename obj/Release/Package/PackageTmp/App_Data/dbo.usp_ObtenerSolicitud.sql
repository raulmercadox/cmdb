alter procedure dbo.usp_ObtenerSolicitud
@id int
as
select Id,ProyectoId,FechaCreacion,usuarioid,analistades,analistatestprod,CopiarA,ambienteid,nombrearchivo1,nombrearchivo2,nombrearchivo3,nombrearchivo4,
nombrearchivo5,nombrearchivo6,nombrearchivo7,nombrearchivo8,nombrearchivo9,nombrearchivo10,emergente,RazonEmergente,Estado,Area1,Area2,Area3,Area4,
Area5,Area6,Area7,Area8,Area9,Area10,VentanaId,EjecutarEmergente,
FechaArchivo1,FechaArchivo2,FechaArchivo3,FechaArchivo4,FechaArchivo5,FechaArchivo6,FechaArchivo7,FechaArchivo8,FechaArchivo9,FechaArchivo10,
Comentario1,Comentario2,Comentario3,Comentario4,Comentario5,Comentario6,Comentario7,Comentario8,Comentario9,Comentario10,
Estado1,Estado2,Estado3,Estado4,Estado5,Estado6,Estado7,Estado8,Estado9,Estado10,FechaEjecucion,RFC,FechaReversion,Reversion,Principal,Adicional,Regularizacion
from dbo.Solicitud
where Id = @id