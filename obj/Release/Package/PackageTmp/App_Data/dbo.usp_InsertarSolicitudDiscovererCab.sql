create procedure dbo.usp_InsertarSolicitudDiscovererCab
@SolicitudId int,
@NumeroArchivo int,
@CodigoProyecto varchar(50),
@Ambiente varchar(50),
@Observaciones varchar(50)
as
insert into dbo.SolicitudDiscovererCab(SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente,Observaciones)
values (@SolicitudId,@NumeroArchivo,@CodigoProyecto,@Ambiente,@Observaciones)

select @@IDENTITY