create procedure dbo.usp_InsertarSolicitudOSB11gConfigCab
@SolicitudId int,
@NumeroArchivo int,
@CodigoProyecto varchar(50),
@Ambiente varchar(50),
@ServidorDestino varchar(50),
@Observaciones varchar(max)
as
insert into dbo.SolicitudOSB11gConfigCab (SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente,ServidorDestino,Observaciones)
values (@SolicitudId,@NumeroArchivo,@CodigoProyecto,@Ambiente,@ServidorDestino,@Observaciones)

select @@IDENTITY