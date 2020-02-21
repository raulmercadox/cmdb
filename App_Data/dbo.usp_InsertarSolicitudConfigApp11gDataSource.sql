create procedure dbo.usp_InsertarSolicitudConfigApp11gDataSource
@solicitudid int,
@numeroarchivo int,
@responsable varchar(100),
@analistadesarrollo varchar(100),
@accion varchar(100),
@nombre varchar(100),
@servercluster varchar(100),
@jndiname varchar(100),
@url varchar(100),
@driverclassname varchar(100),
@user varchar(100),
@capacityinitial varchar(100),
@capacitymaximun varchar(100),
@capacityminimun varchar(100),
@supportglobal varchar(100),
@statementcache varchar(100),
@inactiveconnection varchar(100),
@testconnection varchar(100)
as
insert into dbo.SolicitudConfigApp11gDataSource (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,ServerCluster,JndiName,Url,DriverClassName,[User],
CapacityInitial,CapacityMaximun,CapacityMinimun,SupportGlobal,StatementCache,InactiveConnection,TestConnection)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Nombre,@ServerCluster,@JndiName,@Url,@DriverClassName,@User,
@CapacityInitial,@CapacityMaximun,@CapacityMinimun,@SupportGlobal,@StatementCache,@InactiveConnection,@TestConnection)

select @@IDENTITY