create procedure dbo.usp_InsertarSolicitudBDCampo
@solicitudid int,
@numeroarchivo int,
@instanciaid int,
@esquemaid int,
@nombretabla varchar(50),
@tipoaccionbdid int,
@nombrecolumna varchar(50),
@tipo varchar(50),
@comentario varchar(50),
@notnull varchar(1),
@defaultvalue varchar(50),
@checkvalue varchar(50)
as
insert into dbo.SolicitudBDCampo(solicitudid,numeroarchivo,instanciaid,esquemaid,nombretabla,tipoaccionbdid,nombrecolumna,tipo,comentario,notnull,defaultvalue,checkvalue)
values (@solicitudid,@numeroarchivo,@instanciaid,@esquemaid,@nombretabla,@tipoaccionbdid,@nombrecolumna,@tipo,@comentario,@notnull,@defaultvalue,@checkvalue)