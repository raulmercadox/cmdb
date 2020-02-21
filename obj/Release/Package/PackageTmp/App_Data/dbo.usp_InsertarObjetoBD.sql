alter procedure dbo.usp_InsertarObjetoBD
@solicitudid int,
@numeroarchivo int,
@instanciaid int,
@esquemaid int = null,
@tipoobjetoid int,
@tipoaccionid int,
@ruta varchar(500),
@nombre varchar(50),
@informacionadicional varchar(max)
as
insert into dbo.SolicitudBD (SolicitudId,NumeroArchivo,InstanciaId,EsquemaId,TipoObjetoBDId,TipoAccionBDId,Ruta,ObjetoBD,InformacionAdicional)
values (@solicitudid,@numeroarchivo,@instanciaid,@esquemaid,@tipoobjetoid,@tipoaccionid,@ruta,@nombre,@informacionadicional)

select @@identity