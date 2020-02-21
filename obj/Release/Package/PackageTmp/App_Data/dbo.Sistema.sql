alter table dbo.Sistema
add MensajeCrearSolicitud varchar(max) not null constraint DF_Sistema_MensajeCrearSolicitud default ''
