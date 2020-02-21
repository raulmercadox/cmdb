create procedure dbo.usp_InsertarSolicitudCRMCab
@solicitudid int,
@numeroarchivo int,
@observacion varchar(max),
@servidordestino varchar(100)
as
insert into dbo.SolicitudCRMCab (SolicitudId,NumeroArchivo,Observacion,ServidorDestino)
values (@solicitudid,@numeroarchivo,@observacion,@servidordestino)

select @@IDENTITY