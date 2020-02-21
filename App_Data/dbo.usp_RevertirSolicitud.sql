create procedure dbo.usp_RevertirSolicitud
@solicitudid int
as
declare @logid int
declare @estado varchar(50)

select @logid=MAX(sl.id) 
from dbo.SolicitudLog sl
where sl.SolicitudId=@solicitudid

delete from dbo.SolicitudLog 
where id=@logid

select @logid=MAX(sl.id) 
from dbo.SolicitudLog sl
where sl.SolicitudId=@solicitudid

select @estado=sl.Estado 
from dbo.SolicitudLog sl
where sl.Id = @logid

update dbo.Solicitud set Estado=@estado where Id=@solicitudid