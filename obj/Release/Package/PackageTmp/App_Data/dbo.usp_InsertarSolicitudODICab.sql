create procedure dbo.usp_InsertarSolicitudODICab
@SolicitudId int,
@NumeroArchivo int,
@CodigoProyecto varchar(50),
@Ambiente varchar(50)
as
insert into dbo.SolicitudODICab(SolicitudId,NumeroArchivo,CodigoProyecto,Ambiente)
values (@SolicitudId,@NumeroArchivo,@CodigoProyecto,@Ambiente)

select @@IDENTITY