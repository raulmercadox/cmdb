alter procedure dbo.usp_ActualizarRMSolicitadoxSol
@id int,
@estado varchar(50),
@area1 int,
@area2 int,
@area3 int,
@area4 int,
@area5 int,
@area6 int,
@area7 int,
@area8 int,
@area9 int,
@area10 int,
@copiara varchar(200),
@ventanaid int = null,
@ejecutaremergente bit
as
update dbo.Solicitud 
set estado=@estado,
Area1=case when @area1=0 then null else @area1 end,
Area2=case when @area2=0 then null else @area2 end,
Area3=case when @area3=0 then null else @area3 end,
Area4=case when @area4=0 then null else @area4 end,
Area5=case when @area5=0 then null else @area5 end,
Area6=case when @area6=0 then null else @area6 end,
Area7=case when @area7=0 then null else @area7 end,
Area8=case when @area8=0 then null else @area8 end,
Area9=case when @area9=0 then null else @area9 end,
Area10=case when @area10=0 then null else @area10 end,
CopiarA = @copiara,VentanaId = @ventanaid,EjecutarEmergente = @ejecutaremergente
where Id = @Id

select @id