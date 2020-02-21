alter procedure [dbo].[usp_InsertarSolicitudLog]
@SolicitudId int,
@Accion varchar(50),
@Estado varchar(50),
@UsuarioId int,
@FechaHora datetime,
@Comentario varchar(max),
@ObservacionId int = null,
@Archivo varbinary(MAX) = null,
@NombreArchivo varchar(100) = null
as
insert into dbo.SolicitudLog (SolicitudId,Accion,Estado,UsuarioId,FechaHora,Comentario,ObservacionId,Archivo,NombreArchivo)
values (@SolicitudId,@Accion,@Estado,@UsuarioId,@FechaHora,@Comentario,@ObservacionId,@Archivo,@NombreArchivo)

select @@IDENTITY