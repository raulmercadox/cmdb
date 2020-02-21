alter procedure dbo.usp_InsertarAprobacion
@archivo varbinary(max),
@nombrearchivo varchar(100),
@solicitudid int,
@fechahora datetime = null,
@contenttype varchar(max) = ''
as
insert into dbo.SolicitudAprobacion(solicitudid,nombrearchivo,contenido,fechahora,contenttype)
values (@solicitudid, @nombrearchivo, @archivo, @fechahora, @contenttype)

select @@identity