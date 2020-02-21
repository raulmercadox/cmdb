create procedure dbo.usp_InsertarSolicitudSOAConfigInstanciasJ2EE
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@Nombre varchar(50),
@PuertoRMI varchar(50),
@MaximumHeap varchar(50),
@InitialHeap varchar(50),
@OpcionesAdicionales varchar(50)
as
insert into dbo.SolicitudSOAConfigInstanciasJ2EE (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Nombre,PuertoRMI,MaximumHeap,InitialHeap,OpcionesAdicionales)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Nombre,@PuertoRMI,@MaximumHeap,@InitialHeap,@OpcionesAdicionales)

select @@IDENTITY