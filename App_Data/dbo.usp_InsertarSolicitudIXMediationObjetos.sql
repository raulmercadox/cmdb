create procedure dbo.usp_InsertarSolicitudIXMediationObjetos
@solicitudid int,
@numeroarchivo int,
@Orden varchar(50),
@Directorio varchar(50),
@Nombre varchar(50),
@Tipo varchar(50),
@Accion varchar(50),
@Observacion varchar(50)
as
insert into dbo.SolicitudIXMediationObjetos (SolicitudId,NumeroArchivo,Orden,Directorio,Nombre,Tipo,Accion,Observacion)
values (@solicitudid,@numeroarchivo,@Orden,@Directorio,@Nombre,@Tipo,@Accion,@Observacion)

select @@IDENTITY