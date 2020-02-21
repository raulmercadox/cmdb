alter procedure [dbo].[usp_CrearServidor]
@nombreservidor varchar(50),
@ipservidor varchar(15),
@ambienteid int,
@descripcion varchar(max)=''
as
insert into dbo.Servidor (nombre, ip, AmbienteId,descripcion) values (@nombreservidor, @ipservidor, case when @ambienteid = 0 then null else @ambienteid end,@descripcion)
select @@IDENTITY