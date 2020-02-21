alter procedure dbo.usp_ListarConflictoBD
 @SolicitudId int,
 @NumeroArchivo int
 as
 -- BUSCAR EN SOLICITUDES PENDIENTES
 select ProyDestino.Id ProyectoId,b.SolicitudId,b.instanciaId,b.EsquemaId,b.TipoObjetoBDId,b.ObjetoBD,MAX(SolLogDestino.FechaHora) FechaPase
 into #SolPen1
 from dbo.SolicitudBD a 
 inner join dbo.SolicitudBD b on a.InstanciaId = b.InstanciaId and a.EsquemaId = b.EsquemaId and a.TipoObjetoBDId = b.TipoObjetoBDId and 
 dbo.ufn_QuitarPunto(a.ObjetoBD) = dbo.ufn_QuitarPunto(b.ObjetoBD)
 and a.SolicitudId<>b.SolicitudId
 inner join dbo.Solicitud SolOrigen on a.SolicitudId = SolOrigen.Id
 inner join dbo.Solicitud SolDestino on b.SolicitudId = SolDestino.Id
 inner join dbo.Estado EstadoDestino on SolDestino.Estado = EstadoDestino.Nombre and EstadoDestino.Pendiente = 1
 inner join dbo.Proyecto ProyOrigen on SolOrigen.ProyectoId = ProyOrigen.Id
 inner join dbo.Proyecto ProyDestino on SolDestino.ProyectoId = ProyDestino.Id and ProyOrigen.Id <> ProyDestino.Id
 inner join dbo.SolicitudLog SolLogDestino on b.SolicitudId = SolLogDestino.SolicitudId
 where a.SolicitudId=@SolicitudId and a.NumeroArchivo=@NumeroArchivo
 group by ProyDestino.Id,b.SolicitudId,b.InstanciaId,b.EsquemaId,b.TipoObjetoBDId,b.ObjetoBD,EstadoDestino.Nombre
 
 -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 select ProyectoId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD,MAX(FechaPase) FechaPase
 into #SolPen2
 from #SolPen1
 group by ProyectoId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD
  --------------------------------------------------
 select a.ProyectoId,a.SolicitudId,a.InstanciaId,a.EsquemaId,a.TipoObjetoBDId,a.ObjetoBD
 into #SolPendientes
 from #SolPen1 a
 inner join #SolPen2 b on a.ProyectoId=b.ProyectoId and a.InstanciaId = b.InstanciaId and a.EsquemaId = b.EsquemaId and a.TipoObjetoBDId = b.TipoObjetoBDId and 
	dbo.ufn_QuitarPunto(a.ObjetoBD) = dbo.ufn_QuitarPunto(b.ObjetoBD) 
	and a.FechaPase = b.FechaPase
--------------------------------------------------------------------------------------------------------------------------------

-- BUSCAR EN SOLICITUDES TERMINADAS QUE NO HAN PASADO AL SIGUIENTE AMBIENTE DE MANERA SATISFACTORIA
 select ProyDestino.Id ProyectoId,b.SolicitudId,b.instanciaId,b.EsquemaId,b.TipoObjetoBDId,b.ObjetoBD,MAX(SolLogDestino.FechaHora) FechaPase
 into #SolTer1
 from dbo.SolicitudBD a 
 inner join dbo.SolicitudBD b on a.InstanciaId = b.InstanciaId and a.EsquemaId = b.EsquemaId and a.TipoObjetoBDId = b.TipoObjetoBDId and 
 dbo.ufn_QuitarPunto(a.ObjetoBD) = dbo.ufn_QuitarPunto(b.ObjetoBD) 
 and a.SolicitudId<>b.SolicitudId
 inner join dbo.Solicitud SolOrigen on a.SolicitudId = SolOrigen.Id
 inner join dbo.Solicitud SolDestino on b.SolicitudId = SolDestino.Id
 inner join dbo.Estado EstadoDestino on SolDestino.Estado = EstadoDestino.Nombre and EstadoDestino.Satisfactorio = 1
 inner join dbo.Proyecto ProyOrigen on SolOrigen.ProyectoId = ProyOrigen.Id
 inner join dbo.Proyecto ProyDestino on SolDestino.ProyectoId = ProyDestino.Id and ProyOrigen.Id <> ProyDestino.Id
 inner join dbo.SolicitudLog SolLogDestino on b.SolicitudId = SolLogDestino.SolicitudId
 where a.SolicitudId=@SolicitudId and a.NumeroArchivo=@NumeroArchivo
 group by ProyDestino.Id,b.SolicitudId,b.InstanciaId,b.EsquemaId,b.TipoObjetoBDId,b.ObjetoBD,EstadoDestino.Nombre
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 select ProyectoId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD,MAX(FechaPase) FechaPase
 into #SolTer2
 from #SolTer1
 group by ProyectoId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD
 --------------------------------------------------
 select a.ProyectoId,a.SolicitudId,a.InstanciaId,a.EsquemaId,a.TipoObjetoBDId,a.ObjetoBD,b.FechaPase
 into #SolTerminadas
 from #SolTer1 a
 inner join #SolTer2 b on a.ProyectoId=b.ProyectoId and a.InstanciaId = b.InstanciaId and a.EsquemaId = b.EsquemaId and a.TipoObjetoBDId = b.TipoObjetoBDId and 
	dbo.ufn_QuitarPunto(a.ObjetoBD) = dbo.ufn_QuitarPunto(b.ObjetoBD) and a.FechaPase = b.FechaPase
--------------------------------------------------------------------------------------------------------------------------------
 select objant.ProyectoId,objant.SolicitudId SolAntId,objant.FechaPase FechaAnt,objant.InstanciaId InstanciaAntId,objant.EsquemaId EsquemaAntId,objant.TipoObjetoBDId,objant.ObjetoBD,instancia.Id InstanciaPostId,esqpost.Id EsquemaPostId
 into #objpost1
 from #SolTerminadas objant
 inner join dbo.Instancia instancia on objant.InstanciaId = instancia.InstanciaAnteriorId
 inner join dbo.Esquema esqant on objant.EsquemaId = esqant.Id
 inner join dbo.Esquema esqpost on esqant.Nombre = esqpost.Nombre and esqpost.InstanciaId = instancia.Id
 
 -- select * from #objpost1
 
 select objpost.ProyectoId,objpost.InstanciaPostId,objpost.EsquemaPostId,objpost.TipoObjetoBDId,objpost.ObjetoBD,MAX(sollog.FechaHora) fechahora
 into #objpost2
 from #objpost1 objpost
 inner join SolicitudBD solbd on objpost.InstanciaPostId = solbd.InstanciaId and objpost.EsquemaPostId = solbd.EsquemaId and objpost.TipoObjetoBDId = solbd.TipoObjetoBDId and
	dbo.ufn_QuitarPunto(objpost.ObjetoBD) = dbo.ufn_QuitarPunto(solbd.ObjetoBD)
 inner join Solicitud sol on solbd.SolicitudId = sol.Id
 inner join Proyecto proy on sol.ProyectoId = proy.Id and objpost.ProyectoId = proy.Id
 inner join Estado est on sol.Estado = est.Nombre and est.Satisfactorio=1
 inner join SolicitudLog sollog on sol.Id = sollog.SolicitudId
 group by objpost.ProyectoId,objpost.InstanciaPostId,objpost.EsquemaPostId,objpost.TipoObjetoBDId,objpost.ObjetoBD
 
 select objpost1.ProyectoId,objpost1.SolAntId SolicitudId,objpost1.InstanciaAntId InstanciaId,objpost1.EsquemaAntId EsquemaId,objpost1.TipoObjetoBDId,objpost1.ObjetoBD
 into #SolTerminadasSinPasePosterior
 from #objpost1 objpost1
 left join #objpost2 objpost2 on objpost1.ProyectoId = objpost2.ProyectoId and objpost1.InstanciaPostId = objpost2.InstanciaPostId and objpost1.EsquemaPostId = objpost2.EsquemaPostId
	and objpost1.TipoObjetoBDId = objpost2.TipoObjetoBDId and dbo.ufn_QuitarPunto(objpost1.ObjetoBD) = dbo.ufn_QuitarPunto(objpost2.ObjetoBD)
 where objpost2.ProyectoId is null or objpost1.FechaAnt > objpost2.fechahora
 
 
 -- BUSCAR SOLICITUDES QUE SE ENCUENTREN EN EL AMBIENTE PREVIO Y QUE AUN NO HAYAN PASADO AL AMBIENTE ACTUAL
 select proy.Id ProyectoId,instancia.InstanciaAnteriorId InstanciaId,esqant.Id EsquemaId,solbd.TipoObjetoBDId,solbd.ObjetoBD
 into #prefab1
 from dbo.SolicitudBD solbd
 inner join dbo.Instancia instancia on solbd.InstanciaId = instancia.Id
 inner join dbo.Esquema esqpost on solbd.EsquemaId = esqpost.Id
 inner join dbo.Esquema esqant on esqpost.Nombre = esqant.Nombre and instancia.InstanciaAnteriorId=esqant.InstanciaId
 inner join dbo.Solicitud sol on solbd.SolicitudId = sol.Id
 inner join dbo.Proyecto proy on sol.ProyectoId = proy.Id
 where solbd.SolicitudId=@SolicitudId and solbd.NumeroArchivo = @NumeroArchivo
 
 select MAX(solbd.SolicitudId) SolicitudId,solbd.InstanciaId,solbd.EsquemaId,solbd.TipoObjetoBDId,solbd.ObjetoBD
 into #prefab2
 from #prefab1 prefab1
 inner join dbo.SolicitudBD solbd on prefab1.InstanciaId = solbd.InstanciaId and prefab1.EsquemaId=solbd.EsquemaId and prefab1.TipoObjetoBDId=solbd.TipoObjetoBDId 
	and dbo.ufn_QuitarPunto(prefab1.ObjetoBD) = dbo.ufn_QuitarPunto(solbd.ObjetoBD)
 inner join dbo.Solicitud sol on solbd.SolicitudId = sol.Id
 inner join dbo.Proyecto proy on sol.ProyectoId = proy.Id and prefab1.ProyectoId = proy.Id
 inner join dbo.Estado estado on sol.Estado = estado.Nombre and estado.Satisfactorio = 1
 group by solbd.InstanciaId,solbd.EsquemaId,solbd.TipoObjetoBDId,solbd.ObjetoBD
 
 ---------------------------------------------------------------------------------------------------------------------------------------------------------------------
  
 select ProyDestino.Id ProyectoId,b.SolicitudId,b.instanciaId,b.EsquemaId,b.TipoObjetoBDId,b.ObjetoBD,MAX(SolLogDestino.FechaHora) FechaPase
 into #SolPast1
 from #prefab2 a 
 inner join dbo.SolicitudBD b on a.InstanciaId = b.InstanciaId and a.EsquemaId = b.EsquemaId and a.TipoObjetoBDId = b.TipoObjetoBDId 
 and dbo.ufn_QuitarPunto(a.ObjetoBD) = dbo.ufn_QuitarPunto(b.ObjetoBD) and a.SolicitudId<>b.SolicitudId
 inner join dbo.Solicitud SolOrigen on a.SolicitudId = SolOrigen.Id
 inner join dbo.Solicitud SolDestino on b.SolicitudId = SolDestino.Id
 inner join dbo.Estado EstadoDestino on SolDestino.Estado = EstadoDestino.Nombre and EstadoDestino.Satisfactorio = 1
 inner join dbo.Proyecto ProyOrigen on SolOrigen.ProyectoId = ProyOrigen.Id
 inner join dbo.Proyecto ProyDestino on SolDestino.ProyectoId = ProyDestino.Id and ProyOrigen.Id <> ProyDestino.Id
 inner join dbo.SolicitudLog SolLogDestino on b.SolicitudId = SolLogDestino.SolicitudId
 group by ProyDestino.Id,b.SolicitudId,b.InstanciaId,b.EsquemaId,b.TipoObjetoBDId,b.ObjetoBD,EstadoDestino.Nombre
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 select ProyectoId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD,MAX(FechaPase) FechaPase
 into #SolPast2
 from #SolPast1
 group by ProyectoId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD
 --------------------------------------------------
 select a.ProyectoId,a.SolicitudId,a.InstanciaId,a.EsquemaId,a.TipoObjetoBDId,a.ObjetoBD,b.FechaPase
 into #SolPasadas
 from #SolPast1 a
 inner join #SolPast2 b on a.ProyectoId=b.ProyectoId and a.InstanciaId = b.InstanciaId and a.EsquemaId = b.EsquemaId and a.TipoObjetoBDId = b.TipoObjetoBDId and 
	dbo.ufn_QuitarPunto(a.ObjetoBD) = dbo.ufn_QuitarPunto(b.ObjetoBD) and a.FechaPase = b.FechaPase
--------------------------------------------------------------------------------------------------------------------------------
 select objant.ProyectoId,objant.SolicitudId SolAntId,objant.FechaPase FechaAnt,objant.InstanciaId InstanciaAntId,objant.EsquemaId EsquemaAntId,
 objant.TipoObjetoBDId,objant.ObjetoBD,instancia.Id InstanciaPostId,esqpost.Id EsquemaPostId
 into #objpast1
 from #SolPasadas objant
 inner join dbo.Instancia instancia on objant.InstanciaId = instancia.InstanciaAnteriorId
 inner join dbo.Esquema esqant on objant.EsquemaId = esqant.Id
 inner join dbo.Esquema esqpost on esqant.Nombre = esqpost.Nombre and esqpost.InstanciaId = instancia.Id
 
 -- select * from #objpost1
 
 select objpost.ProyectoId,objpost.InstanciaPostId,objpost.EsquemaPostId,objpost.TipoObjetoBDId,objpost.ObjetoBD,MAX(sollog.FechaHora) fechahora
 into #objpast2
 from #objpast1 objpost
 inner join SolicitudBD solbd on objpost.InstanciaPostId = solbd.InstanciaId and objpost.EsquemaPostId = solbd.EsquemaId and objpost.TipoObjetoBDId = solbd.TipoObjetoBDId and
	dbo.ufn_QuitarPunto(objpost.ObjetoBD) = dbo.ufn_QuitarPunto(solbd.ObjetoBD)
 inner join Solicitud sol on solbd.SolicitudId = sol.Id
 inner join Proyecto proy on sol.ProyectoId = proy.Id and objpost.ProyectoId = proy.Id
 inner join Estado est on sol.Estado = est.Nombre and est.Satisfactorio=1
 inner join SolicitudLog sollog on sol.Id = sollog.SolicitudId
 group by objpost.ProyectoId,objpost.InstanciaPostId,objpost.EsquemaPostId,objpost.TipoObjetoBDId,objpost.ObjetoBD
 
 select objpost1.ProyectoId,objpost1.SolAntId SolicitudId,objpost1.InstanciaAntId InstanciaId,objpost1.EsquemaAntId EsquemaId,objpost1.TipoObjetoBDId,objpost1.ObjetoBD
 into #SolTerminadasConPaseAnterior
 from #objpast1 objpost1
 left join #objpast2 objpost2 on objpost1.ProyectoId = objpost2.ProyectoId and objpost1.InstanciaPostId = objpost2.InstanciaPostId and objpost1.EsquemaPostId = objpost2.EsquemaPostId
	and objpost1.TipoObjetoBDId = objpost2.TipoObjetoBDId and dbo.ufn_QuitarPunto(objpost1.ObjetoBD) = dbo.ufn_QuitarPunto(objpost2.ObjetoBD)
 where objpost2.ProyectoId is null or objpost1.FechaAnt > objpost2.fechahora
 
 
 ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
  select ProyectoId,SolicitudId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD
  into #ConflictoBD1
  from #SolPendientes
  union all
  select ProyectoId,SolicitudId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD
  from #SolTerminadasSinPasePosterior
  union all
  select ProyectoId,SolicitudId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD
  from #SolTerminadasConPaseAnterior
  
  select distinct ProyectoId,SolicitudId,InstanciaId,EsquemaId,TipoObjetoBDId,ObjetoBD
  into #ConflictoBD2
  from #ConflictoBD1
  
  select a.ProyectoId,a.InstanciaId,a.EsquemaId,a.TipoObjetoBDId,a.ObjetoBD,max(a.SolicitudId) SolicitudId
  into #ConflictoBD3
  from #ConflictoBD2 a
  group by a.ProyectoId,a.InstanciaId,a.EsquemaId,a.TipoObjetoBDId,a.ObjetoBD
  
  select p.id ProyectoId,p.Codigo CodigoProyecto,p.Nombre NombreProyecto,a.SolicitudId,i.Id InstanciaId,i.Nombre NombreInstancia,e.Id EsquemaId,e.Nombre NombreEsquema,
  t.Id tipoobjetobdid,t.Nombre nombretipoobjetobd,a.ObjetoBD,s.Estado,MAX(l.FechaHora) fechahora
  --into #ConflictoBD3
  from #ConflictoBD3 a
  inner join dbo.Proyecto p on a.ProyectoId = p.Id
  inner join dbo.Instancia i on a.InstanciaId = i.Id
  inner join dbo.Esquema e on a.EsquemaId = e.Id
  inner join dbo.TipoObjetoBD t on a.TipoObjetoBDId = t.Id
  inner join dbo.SolicitudLog l on a.SolicitudId = l.SolicitudId
  inner join dbo.Solicitud s on a.SolicitudId = s.Id
  group by p.id,p.Codigo,p.Nombre,a.SolicitudId,i.Id,i.Nombre,e.Id,e.Nombre,t.Id,t.Nombre,a.ObjetoBD,s.Estado
  order by p.Codigo,a.SolicitudId,i.Nombre,e.Nombre,t.Nombre,a.ObjetoBD