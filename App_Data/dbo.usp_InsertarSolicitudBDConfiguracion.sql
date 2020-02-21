create procedure dbo.usp_InsertarSolicitudBDConfiguracion
@solicitudid int,
@numeroarchivo int,
@instanciaid int,
@esquemaid int,
@tabla varchar(50),
@comentario varchar(max),
@archivo varchar(50),
@tipo varchar(50)
as
insert into dbo.SolicitudBDConfiguracion (SolicitudId,NumeroArchivo,InstanciaId,EsquemaId,Tabla,Comentario,Archivo,Tipo)
values (@solicitudid,@numeroarchivo,@instanciaid,@esquemaid,@tabla,@comentario,@archivo,@tipo)

select @@IDENTITY