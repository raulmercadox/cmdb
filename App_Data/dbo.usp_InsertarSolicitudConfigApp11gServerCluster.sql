create procedure dbo.usp_InsertarSolicitudConfigApp11gServerCluster
@solicitudid int,
@numeroarchivo int,
@responsable varchar(100),
@analistadesarrollo varchar(100),
@accion varchar(100),
@servercluster varchar(100),
@nombre varchar(100),
@destino varchar(100),
@parametros varchar(100),
@valor varchar(100),
@detalles varchar(100),
@puerto varchar(100)
as
insert into dbo.SolicitudConfigApp11gServerCluster (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,ServerCluster,Nombre,Destino,Parametros,Valor,Detalles,
Puerto)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@ServerCluster,@Nombre,@Destino,@parametros,@Valor,
@Detalles,@Puerto)

select @@IDENTITY