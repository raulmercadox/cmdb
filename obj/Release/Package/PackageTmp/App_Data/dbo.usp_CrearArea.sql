alter procedure [dbo].[usp_CrearArea]
@nombre varchar(100),
@color varchar(50),
@abreviatura varchar(10)
as
insert into dbo.Area (nombre, color, abreviatura) values (@nombre,@color,@abreviatura)

select @@IDENTITY
