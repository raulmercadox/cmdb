create procedure dbo.usp_InsertarSolicitudPBCab
@SolicitudId int,
@NumeroArchivo int,
@CodigoProyecto varchar(50),
@Ambiente varchar(50),
@Aplicacion varchar(50),
@TipoPase varchar(50),
@Observaciones varchar(max)
as
insert into dbo.SolicitudPBCab (SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente,Aplicacion,TipoPase,Observaciones)
values (@SolicitudId,@NumeroArchivo,@CodigoProyecto,@Ambiente,@Aplicacion,@TipoPase,@Observaciones)

select @@IDENTITY