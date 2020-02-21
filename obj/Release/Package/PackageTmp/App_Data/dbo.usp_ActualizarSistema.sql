alter procedure dbo.usp_ActualizarSistema
@primerasolicitud varchar(max),
@OracleDBUExtractConexion varchar(max),
@estadoId int = 0,
@carpetatrabajo varchar(max),
@CorreoCMS varchar(100),
@ResponderA varchar(100),
@CopiarExcelA varchar(100),
@FolderPre varchar(100),
@FolderDML varchar(100),
@MensajeCrearSolicitud varchar(max)
as
update dbo.Sistema set PrimeraSolicitud=@primerasolicitud,OracleDBUExtractConexion=@OracleDBUExtractConexion,
estadoid = case when @estadoid=0 then null else @estadoId end,carpetatrabajo = @carpetatrabajo,
CorreoCMS = @CorreoCMS,ResponderA = @ResponderA,CopiarExcelA = @CopiarExcelA,FolderPre = @FolderPre,FolderDML=@FolderDML,
MensajeCrearSolicitud = @MensajeCrearSolicitud