alter procedure dbo.usp_ActualizarSolicitudAprobacion
@aprobacionid int,
@areaid int,
@fechahora datetime = null,
@contenttype varchar(max) = ''
as
update dbo.SolicitudAprobacion 
set areaid=case when @areaid=0 then null else @areaid end, fechahora = @fechahora,contenttype=@contenttype
where Id=@aprobacionid