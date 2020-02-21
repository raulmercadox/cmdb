alter table dbo.SolicitudBD
add InformacionAdicional varchar(max) not null
ADD CONSTRAINT [DF_SolicitudBD_InformacionAdicional]  DEFAULT ('') FOR [InformacionAdicional]