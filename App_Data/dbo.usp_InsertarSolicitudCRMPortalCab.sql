create procedure dbo.usp_InsertarSolicitudCRMPortalCab
@SolicitudId int,
@NumeroArchivo int,
@CodigoProyecto varchar(50),
@Ambiente varchar(50),
@Destino varchar(50),
@Observaciones varchar(max)
as
insert into dbo.SolicitudCRMPortalCab (SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente,Destino,Observaciones)
values (@SolicitudId,@NumeroArchivo,@CodigoProyecto,@Ambiente,@Destino,@Observaciones)

select @@IDENTITY