CREATE procedure dbo.usp_InsertarSolicitudAndroidCab
@solicitudid int,
@numeroarchivo int,
@observaciones varchar(max)
as
insert into dbo.SolicitudAndroidCab (SolicitudId,NumeroArchivo,Observaciones)
values (@solicitudid,@numeroarchivo,@observaciones)

select @@IDENTITY
