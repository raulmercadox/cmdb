USE [cmdb]
GO
/****** Object:  UserDefinedFunction [dbo].[ufn_QuitarPunto]    Script Date: 02/26/2015 18:39:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
ALTER FUNCTION [dbo].[ufn_QuitarPunto]
(@valor varchar(max))
RETURNS varchar(max)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @resultado varchar(100)

	-- Add the T-SQL statements to compute the return value here
	SELECT @resultado = SUBSTRING(@valor,1,case when CHARINDEX('.',@valor)>0 then CHARINDEX('.',@valor)-1 else LEN(@valor) end)

	-- Return the result of the function
	RETURN @resultado

END
