create procedure dbo.usp_InsertarSolicitudOSB11gConfigColas
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@Nombre varchar(50),
@ServerCluster varchar(50),
@JNDIName varchar(100),
@Template varchar(50),
@SubDeployment varchar(50),
@Target varchar(50),
@RedeliveryOverride varchar(50),
@RedeliveryLimit varchar(50),
@ExpirationPolicy varchar(50),
@ErrorDestination varchar(50),
@Observacion varchar(100),
@ModuloJMS varchar(50)
as
insert into dbo.SolicitudOSB11gConfigColas (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,ServerCluster,JNDIName,Template,SubDeployment,[Target],RedeliveryOverride,
RedeliveryLimit,ExpirationPolicy,ErrorDestination,Observacion,ModuloJMS)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Nombre,@ServerCluster,@JNDIName,@Template,@SubDeployment,@Target,@RedeliveryOverride,
@RedeliveryLimit,@ExpirationPolicy,@ErrorDestination,@Observacion,@ModuloJMS)

select @@IDENTITY