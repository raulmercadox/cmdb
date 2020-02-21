alter procedure dbo.usp_ActualizarSolObservadoxRM
@id int,
@ambienteid int,
@proyectoid int,
@analistades varchar(100),
@analistatestprod varchar(100),
@copiara varchar(200),
@emergente bit,
@razonemergente varchar(200),
@estado varchar(50),
@fechaejecucion datetime = null,
@fechareversion datetime = null,
@rfc varchar(10) = '',
@reversion bit,
@principal bit=0,
@adicional bit=0,
@regularizacion bit=0
as
update dbo.Solicitud set ambienteid=@ambienteid,proyectoid=@proyectoid,AnalistaDes=@analistades,AnalistaTestProd=@analistatestprod,
CopiarA=@copiarA,Emergente=@emergente,RazonEmergente=@razonemergente,Estado=@estado,FechaEjecucion=@fechaejecucion,rfc=@rfc,
fechareversion = @fechareversion,reversion=@reversion,Principal=@principal,Adicional=@Adicional,Regularizacion=@regularizacion
where id=@id

select @id