alter procedure [dbo].[usp_ObtenerServidorPorId]
@Id int
as
select id, nombre, ip, isnull(ambienteid,0) ambienteid,descripcion
from dbo.Servidor
where Id = @Id