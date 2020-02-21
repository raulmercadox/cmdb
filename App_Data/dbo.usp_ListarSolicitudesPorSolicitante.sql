alter procedure dbo.usp_ListarSolicitudesPorSolicitante
@UsuarioId int
as
select top 100 Id,ProyectoId,FechaCreacion,FechaEjecucion,UsuarioId,AnalistaDes,AnalistaTestProd,CopiarA,AmbienteId,Archivo1,Archivo2,Archivo3,Archivo4,Archivo5,
Archivo6,Archivo7,Archivo8,Archivo9,Archivo10,NombreArchivo1,NombreArchivo2,NombreArchivo3,NombreArchivo4,NombreArchivo5,NombreArchivo6,
NombreArchivo7,NombreArchivo8,NombreArchivo9,NombreArchivo10,Emergente,RazonEmergente,Estado,FechaReversion,Reversion,Principal,RFC,Adicional
from dbo.Solicitud
where UsuarioId = @UsuarioId
order by FechaCreacion desc