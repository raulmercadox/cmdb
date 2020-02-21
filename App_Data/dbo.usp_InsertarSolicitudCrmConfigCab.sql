create procedure dbo.usp_InsertarSolicitudCrmConfigCab
@solicitudid int,
@numeroarchivo int,
@observaciones varchar(max),
@servidordestino varchar(100)
as
insert into dbo.SolicitudCrmConfigCab (SolicitudId,NumeroArchivo,Observaciones,ServidorDestino)
values (@solicitudid,@numeroarchivo,@observaciones,@servidordestino)

select @@IDENTITY