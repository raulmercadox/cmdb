create procedure dbo.usp_ListarAmbienteCorreo
@ambienteid int
as
select Id,AmbienteId,Correo
from dbo.AmbienteCorreo
where ambienteId=@ambienteid
order by Correo