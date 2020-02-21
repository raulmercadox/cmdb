create procedure dbo.usp_InsertarSolicitudOSB11gConfigServerCluster
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@ServerCluster varchar(50),
@Nombre varchar(50),
@Servidor varchar(50),
@Parametro varchar(50),
@Valor varchar(50),
@Detalles varchar(50),
@Puerto varchar(50)
as
insert into dbo.SolicitudOSB11gConfigServerCluster (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,ServerCluster,Nombre,Servidor,Parametro,Valor,Detalles,Puerto)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@ServerCluster,@Nombre,@Servidor,@Parametro,@Valor,@Detalles,@Puerto)

select @@IDENTITY