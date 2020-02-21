alter table dbo.Solicitud
add Regularizacion bit not null 
constraint DF_Solicitud_Regularizacion default 0