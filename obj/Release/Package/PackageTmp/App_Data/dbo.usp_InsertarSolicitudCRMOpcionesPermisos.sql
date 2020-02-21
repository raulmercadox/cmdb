create procedure dbo.usp_InsertarSolicitudCRMOpcionesPermisos
@SolicitudId int,
@NumeroArchivo int,
@Campo1 varchar(50),
@Campo2 varchar(50),
@Campo3 varchar(50),
@Campo4 varchar(50),
@Campo5 varchar(50),
@Campo6 varchar(50),
@Campo7 varchar(50),
@Campo8 varchar(50),
@Campo9 varchar(50),
@Campo10 varchar(50),
@Campo11 varchar(50),
@Campo12 varchar(50),
@Campo13 varchar(50),
@Campo14 varchar(50)
as
insert into dbo.SolicitudCRMOpcionesPermisos (SolicitudId,NumeroArchivo,Campo1,Campo2,Campo3,Campo4,Campo5,Campo6,Campo7,Campo8,Campo9,Campo10,Campo11,Campo12,Campo13,Campo14)
values (@SolicitudId,@NumeroArchivo,@Campo1,@Campo2,@Campo3,@Campo4,@Campo5,@Campo6,@Campo7,@Campo8,@Campo9,@Campo10,@Campo11,@Campo12,@Campo13,@Campo14)

select @@IDENTITY