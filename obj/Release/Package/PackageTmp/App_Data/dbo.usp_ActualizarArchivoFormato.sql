alter procedure dbo.usp_ActualizarArchivoFormato
@id int,
@contenido varbinary(max),
@nombre varchar(100),
@codigo varchar(20),
@version varchar(30),
@carpetabase varchar(50)
as
update dbo.Formato set Contenido=@contenido,Nombre=@nombre,Codigo=@codigo,[version]=@version,CarpetaBase=@carpetabase
where id=@id