create procedure dbo.usp_InsertarSolicitudIXMediationCab
@solicitudid int,
@numeroarchivo int,
@codigoproyecto varchar(50),
@ambiente varchar(50),
@observaciones varchar(max)
as
insert into dbo.SolicitudIXMediationCab (SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente,Observaciones)
values (@solicitudid,@numeroarchivo,@codigoproyecto,@ambiente,@observaciones)

select @@IDENTITY