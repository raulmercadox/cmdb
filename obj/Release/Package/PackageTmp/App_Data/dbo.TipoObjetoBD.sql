alter table dbo.TipoObjetoBD
add Extension varchar(20) null
constraint DF_TipoObjetoBD_Extension default ''