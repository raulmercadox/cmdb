﻿create procedure dbo.usp_EliminarSolicitudOSB10gAplicaciones
@solicitudid int,
@numeroarchivo int
as
delete from dbo.SolicitudOSB10gAplicaciones where SolicitudId=@solicitudid and NumeroArchivo=@numeroarchivo