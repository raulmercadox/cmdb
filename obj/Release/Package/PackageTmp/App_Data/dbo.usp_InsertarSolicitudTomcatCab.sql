create procedure dbo.usp_InsertarSolicitudTomcatCab
@solicitudid int,
@numeroarchivo int,
@observaciones varchar(max)
as
insert into dbo.SolicitudTomcatCab (SolicitudId,NumeroArchivo,Observaciones)
values (@solicitudid,@numeroarchivo,@observaciones)

select @@IDENTITY