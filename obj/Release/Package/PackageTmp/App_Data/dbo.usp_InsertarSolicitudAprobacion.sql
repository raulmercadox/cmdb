alter procedure dbo.usp_InsertarSolicitudAprobacion
@SolicitudId int,
@NombreArchivo varchar(100),
@Contenido varbinary(max),
@FechaHora datetime = null,
@ContentType varchar(max) = ''
as
insert into dbo.SolicitudAprobacion(SolicitudId,NombreArchivo,Contenido,FechaHora,ContentType)
values (@SolicitudId,@NombreArchivo,@Contenido,@FechaHora,@ContentType)

select @@IDENTITY