create procedure dbo.usp_InsertarSolicitudPBLibrerias
@SolicitudId int,
@NumeroArchivo int,
@Orden varchar(50),
@GrupoDesarrollo varchar(50),
@Responsable varchar(50),
@AnalistaDesarrollo varchar(50),
@Servidor varchar(50),
@Ruta varchar(100),
@Libreria varchar(50),
@Objeto varchar(50),
@LibreriaDestino varchar(50)
as
insert into dbo.SolicitudPBLibrerias (SolicitudId,NumeroArchivo,Orden,GrupoDesarrollo,Responsable,AnalistaDesarrollo,Servidor,Ruta,Libreria,Objeto,LibreriaDestino)
values (@SolicitudId,@NumeroArchivo,@Orden,@GrupoDesarrollo,@Responsable,@AnalistaDesarrollo,@Servidor,@Ruta,@Libreria,@Objeto,@LibreriaDestino)

select @@IDENTITY