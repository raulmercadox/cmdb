create procedure dbo.usp_InsertarSolicitudOSB10gConfigDataSource
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@Nombre varchar(50),
@ServerCluster varchar(100),
@JNDIName varchar(50),
@URL varchar(100),
@DriverClassName varchar(50),
@User varchar(50),
@CapacityInitial varchar(50),
@CapacityMaximum varchar(50),
@CapacityMinimum varchar(50),
@SupportGlobal varchar(50),
@StatementCache varchar(50),
@InactiveConnection varchar(50),
@TestConnections varchar(50)
as
insert into dbo.SolicitudOSB10gConfigDataSource(SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,ServerCluster,JNDIName,URL,DriverClassName,[User],
CapacityInitial,CapacityMaximum,CapacityMinimum,SupportGlobal,StatementCache,InactiveConnection,TestConnections)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Nombre,@ServerCluster,@JNDIName,@URL,@DriverClassName,@User,
@CapacityInitial,@CapacityMaximum,@CapacityMinimum,@SupportGlobal,@StatementCache,@InactiveConnection,@TestConnections)

select @@IDENTITY