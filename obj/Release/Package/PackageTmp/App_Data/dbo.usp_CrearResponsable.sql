CREATE procedure [dbo].[usp_CrearResponsable]
@nombre varchar(50)
as
insert into dbo.Responsable (nombre) values (@nombre)

select @@identity