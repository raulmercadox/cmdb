create procedure dbo.usp_ActualizarCertificado
@proyectoid int,
@ambienteid int,
@certificado bit,
@fechahora datetime,
@usuarioid int
as
insert into dbo.ProyectoCertificado (proyectoid,ambienteid,usuarioid,fechahora,certificado)
values (@proyectoid,@ambienteid,@usuarioid,@fechahora,@certificado)