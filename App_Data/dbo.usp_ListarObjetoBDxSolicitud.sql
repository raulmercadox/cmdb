alter procedure dbo.usp_ListarObjetoBDxSolicitud
@solicitudid int
as
select instanciaid,esquemaid,tipoobjetobdid,tipoaccionbdid,objetobd
from dbo.solicitudbd
where solicitudid=@solicitudid