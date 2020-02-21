create procedure dbo.usp_InsertarSolicitudCRMOpcionesRoles
@solicitudid int,
@numeroarchivo int,
@responsable varchar(50),
@analistadesarrollo varchar(50),
@moduloaplicacion varchar(50),
@nro varchar(50),
@codigo varchar(50),
@nombre varchar(50),
@npcode varchar(50),
@nplevel varchar(50),
@npmoduleid varchar(50),
@accion varchar(50)
as
insert into dbo.SolicitudCRMOpcionesRoles (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,ModuloAplicacion,Nro,Codigo,Nombre,NPCode,NPLevel,NPModuleId,Accion)
values (@solicitudid,@numeroarchivo,@responsable,@analistadesarrollo,@moduloaplicacion,@nro,@codigo,@nombre,@npcode,@nplevel,@npmoduleid,@accion)

select @@IDENTITY
