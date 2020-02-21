create procedure dbo.usp_InsertarSolicitudOSB11gConfigAdaptadores
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@JNDI varchar(100),
@DataSourceName varchar(50),
@ConnectionInitial varchar(50),
@ConnectionMaximum varchar(50),
@ConnectionMinimum varchar(50)
as
insert into dbo.SolicitudOSB11gConfigAdaptadores (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,JNDI,DataSourceName,ConnectionInitial,ConnectionMaximum,ConnectionMinimum)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@JNDI,@DataSourceName,@ConnectionInitial,@ConnectionMaximum,@ConnectionMinimum)

select @@IDENTITY