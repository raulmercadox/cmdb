create procedure dbo.usp_InsertarSolicitudOSB10gCab
@solicitudid int,
@numeroarchivo int,
@codigoproyecto varchar(50),
@ambiente varchar(50),
@servidordestino varchar(50),
@observaciones varchar(max)
as
insert into dbo.SolicitudOSB10gCab (SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente,ServidorDestino,Observaciones)
values (@solicitudid,@numeroarchivo,@codigoproyecto,@ambiente,@servidordestino,@observaciones)

select @@IDENTITY