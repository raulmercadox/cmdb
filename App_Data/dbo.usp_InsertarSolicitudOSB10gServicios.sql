create procedure dbo.usp_InsertarSolicitudOSB10gServicios
@solicitudid int,
@numeroarchivo int,
@responsable varchar(50),
@analistadesarrollo varchar(50),
@rutaorigen varchar(100),
@accion varchar(50),
@nombrejar varchar(50),
@proyectoservicio varchar(50),
@observacion varchar(100),
@parametrosambiente varchar(50)
as
insert into dbo.SolicitudOSB10gServicios (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,RutaOrigen,Accion,NombreJar,ProyectoServicio,Observacion,ParametrosAmbiente)
values (@solicitudid,@numeroarchivo,@responsable,@analistadesarrollo,@rutaorigen,@accion,@nombrejar,@proyectoservicio,@observacion,@parametrosambiente)

select @@IDENTITY