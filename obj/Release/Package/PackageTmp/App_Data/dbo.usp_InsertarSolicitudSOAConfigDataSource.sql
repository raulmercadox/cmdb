create procedure dbo.usp_InsertarSolicitudSOAConfigDataSource
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@Container varchar(50),
@Nombre varchar(50),
@JNDILocation varchar(50),
@Tipo varchar(50),
@ConnectionPool varchar(50),
@Opciones varchar(50)
as
insert into dbo.SolicitudSOAConfigDataSource (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Container,Nombre,JNDILocation,Tipo,ConnectionPool,Opciones)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Container,@Nombre,@JNDILocation,@Tipo,@ConnectionPool,@Opciones)

select @@IDENTITY