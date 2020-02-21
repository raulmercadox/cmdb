CREATE procedure dbo.usp_InsertarSolicitudApp11gCab
@solicitudid int,
@numeroarchivo int,
@observaciones varchar(max),
@servidordestino varchar(100)
as
insert into dbo.SolicitudApp11gCab (SolicitudId,NumeroArchivo,Observaciones,ServidorDestino)
values (@solicitudid,@numeroarchivo,@observaciones,@servidordestino)

select @@IDENTITY