alter procedure dbo.usp_ListarSolicitudesIngresadas
as
select Id,ProyectoId,FechaCreacion,FechaEjecucion,UsuarioId,AnalistaDes,AnalistaTestProd,CopiarA,AmbienteId,Archivo1,Archivo2,Archivo3,Archivo4,Archivo5,
Archivo6,Archivo7,Archivo8,Archivo9,Archivo10,NombreArchivo1,NombreArchivo2,NombreArchivo3,NombreArchivo4,NombreArchivo5,NombreArchivo6,
NombreArchivo7,NombreArchivo8,NombreArchivo9,NombreArchivo10,Emergente,RazonEmergente,Estado,Principal,RFC
from dbo.Solicitud
where (Estado <> 'Anulado_x_RM' and Estado<>'Anulado_x_Sol' and Estado<>'Cancelado_x_Ejec' and Estado<>'Conforme_x_RM' and Estado<>'Conforme_x_Sol' and
Estado <> 'Rollback_Ejecutado_x_Ejec' and Estado<>'Aprobado_x_RM' and Estado<>'Cancelado_x_RM') 
order by Emergente desc,FechaCreacion