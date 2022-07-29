USE [Lib_Sys]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Get_Allrequest]

SELECT	@return_value as 'Return Value'

GO
