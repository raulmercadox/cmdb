alter procedure dbo.usp_ListarSolicitudesAprobadasRM
as
select Id,ProyectoId,FechaCreacion,FechaEjecucion,UsuarioId,AnalistaDes,AnalistaTestProd,CopiarA,AmbienteId,Archivo1,Archivo2,Archivo3,Archivo4,Archivo5,
Archivo6,Archivo7,Archivo8,Archivo9,Archivo10,NombreArchivo1,NombreArchivo2,NombreArchivo3,NombreArchivo4,NombreArchivo5,NombreArchivo6,
NombreArchivo7,NombreArchivo8,NombreArchivo9,NombreArchivo10,Emergente,RazonEmergente,Estado,Principal,RFC,Area1,Area2,Area3,Area4,Area5,Area6,Area7,Area8,Area9,Area10
from dbo.Solicitud
where Estado = 'Aprobado_x_RM'
order by Emergente desc,FechaCreacion