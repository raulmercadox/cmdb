create procedure dbo.usp_InsertarSolicitudOSB11gCab
@solicitudid int,
@numeroarchivo int,
@codigoproyecto varchar(50),
@ambiente varchar(50),
@servidordestino varchar(50),
@observaciones varchar(max)
as
insert into dbo.SolicitudOSB11gCab (SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente,ServidorDestino,Observaciones)
values (@solicitudid,@numeroarchivo,@codigoproyecto,@ambiente,@servidordestino,@observaciones)

select @@IDENTITY