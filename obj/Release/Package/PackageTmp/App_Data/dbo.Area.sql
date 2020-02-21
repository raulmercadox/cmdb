alter table dbo.Area
add Abreviatura varchar(10) not null
constraint DF_Area_Abreviatura default ''