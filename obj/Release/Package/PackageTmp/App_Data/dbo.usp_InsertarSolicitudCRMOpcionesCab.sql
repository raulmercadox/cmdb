create procedure dbo.usp_InsertarSolicitudCRMOpcionesCab
@solicitudid int,
@numeroarchivo int,
@codigoproyecto varchar(50),
@ambiente varchar(50),
@instancia varchar(50),
@observaciones varchar(50)
as
insert into dbo.SolicitudCRMOpcionesCAB (SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente,Instancia,Observaciones)
values (@SolicitudId,@numeroarchivo,@codigoproyecto,@ambiente,@instancia,@observaciones)

select @@IDENTITY