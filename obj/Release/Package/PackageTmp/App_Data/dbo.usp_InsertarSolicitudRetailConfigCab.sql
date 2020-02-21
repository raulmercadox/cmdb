create procedure dbo.usp_InsertarSolicitudRetailConfigCab
@SolicitudId int,
@NumeroArchivo int,
@CodigoProyecto varchar(50),
@Ambiente varchar(50),
@ServidorDestino varchar(50),
@Observaciones varchar(100),
@ParametrosAmbiente varchar(50)
as
insert into dbo.SolicitudRetailConfigCab (SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente,ServidorDestino,Observaciones,ParametrosAmbiente)
values (@SolicitudId,@NumeroArchivo,@CodigoProyecto,@Ambiente,@ServidorDestino,@Observaciones,@ParametrosAmbiente)

select @@IDENTITY