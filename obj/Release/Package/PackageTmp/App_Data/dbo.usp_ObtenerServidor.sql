alter procedure [dbo].[usp_ObtenerServidor]
@ip varchar(15)
as
select id, nombre, ip, isnull(ambienteid,0) ambienteid,descripcion
from dbo.Servidor
where ip = @ip