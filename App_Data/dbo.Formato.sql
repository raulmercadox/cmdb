alter table dbo.Formato
add Codigo varchar(20) not null 
constraint DF_Formato_Codigo default ''

add [Version] varchar(30) not null 
constraint DF_Formato_Version default ''

add CarpetaBase varchar(50) not null 
constraint DF_Formato_Version default ''