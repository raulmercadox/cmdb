create procedure dbo.usp_InsertarAmbienteCorreo
@ambienteid int,
@correo varchar(100)
as
insert into dbo.AmbienteCorreo (ambienteid,correo) values (@ambienteid,@correo)

select @@IDENTITY