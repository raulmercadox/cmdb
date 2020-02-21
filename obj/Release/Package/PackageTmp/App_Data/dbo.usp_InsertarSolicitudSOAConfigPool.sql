create procedure dbo.usp_InsertarSolicitudSOAConfigPool
@SolicitudId int,
@NumeroArchivo int,
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Accion varchar(50),
@Container varchar(50),
@Nombre varchar(50),
@ConnectionFactory varchar(50),
@URL varchar(50),
@User varchar(50),
@Opciones varchar(50)
as
insert into dbo.SolicitudSOAConfigPool (SolicitudId,NumeroArchivo,Responsable,AnalistaDesarrollo,Accion,Container,Nombre,ConnectionFactory,URL,[User],Opciones)
values (@SolicitudId,@NumeroArchivo,@Responsable,@AnalistaDesarrollo,@Accion,@Container,@Nombre,@ConnectionFactory,@URL,@User,@Opciones)

select @@IDENTITY