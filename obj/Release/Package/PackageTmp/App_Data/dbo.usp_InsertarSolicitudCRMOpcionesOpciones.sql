create procedure dbo.usp_InsertarSolicitudCRMOpcionesOpciones
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@ModuloAplicacion varchar(50),
@Nro varchar(50),
@Codigo varchar(50),
@Descripcion varchar(50),
@Tipo varchar(50),
@Title varchar(50),
@Url varchar(50),
@ParentId varchar(50),
@Accion varchar(50)
as
insert into dbo.SolicitudCRMOpcionesOpciones (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,ModuloAplicacion,Nro,Codigo,Descripcion,Tipo,Title,Url,ParentId,Accion)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@ModuloAplicacion,@Nro,@Codigo,@Descripcion,@Tipo,@Title,@Url,@ParentId,@Accion)

select @@IDENTITY
