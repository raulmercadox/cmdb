alter procedure dbo.usp_ActualizarAprobacion
@id int,
@archivo varbinary(max),
@nombrearchivo varchar(100),
@fechahora datetime = null,
@contenttype varchar(max) = ''
as
update dbo.solicitudAprobacion set contenido=@archivo, nombrearchivo=@nombrearchivo, fechahora=@fechahora, contenttype=@contenttype
where ID=@id