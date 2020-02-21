alter procedure dbo.usp_InsertarSolicitudBDPermisoDBU
@solicitudid int,
@numeroarchivo int,
@instanciaid int,
@esquemaid int,
@tipoobjetobdid int,
@nombreobjeto varchar(50),
@select varchar(1),
@insert varchar(1),
@delete varchar(1),
@update varchar(1),
@execute varchar(1),
@permisoDBU varchar(50)
as
insert into dbo.SolicitudBDPermisoDBU (SolicitudId,NumeroArchivo,InstanciaId,EsquemaId,TipoObjetoBDId,NombreObjeto,[Select],[Insert],[Delete],[Update],[Execute],PermisoDBU)
values (@solicitudid,@numeroarchivo,@instanciaid,@esquemaid,@tipoobjetobdid,@nombreobjeto,@select,@insert,@delete,@update,@execute,@permisoDBU)

select @@identity