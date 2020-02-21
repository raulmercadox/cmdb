create procedure dbo.usp_InsertarSolicitudConfigApp11gCab
@solicitudid int,
@numeroarchivo int,
@observaciones varchar(max),
@servidordestino varchar(100)
as
insert into dbo.SolicitudConfigApp11gCab (SolicitudId,NumeroArchivo,Observaciones,ServidorDestino)
values (@solicitudid,@numeroarchivo,@observaciones,@servidordestino)

select @@IDENTITY