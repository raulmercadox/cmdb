create procedure dbo.usp_InsertarSolicitudOSB11gAplicaciones
@solicitudid int,
@numeroarchivo int,
@responsable varchar(50),
@analistadesarrollo varchar(50),
@rutaorigen varchar(100),
@accion varchar(50),
@tipoinstalacion varchar(50),
@aplicacion varchar(50),
@nombrecluster varchar(50),
@observacion varchar(50),
@parametrosambiente varchar(50)
as
insert into dbo.SolicitudOSB11gAplicaciones (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,RutaOrigen,Accion,TipoInstalacion,Aplicacion,NombreCluster,Observacion,ParametrosAmbiente)
values (@solicitudid,@numeroarchivo,@responsable,@analistadesarrollo,@rutaorigen,@accion,@tipoinstalacion,@aplicacion,@nombrecluster,@observacion,@parametrosambiente)

select @@IDENTITY