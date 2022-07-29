USE [Lib_Sys]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Get_AllLoanlater]
		@return_date = N'23/9/2020'

SELECT	@return_value as 'Return Value'

GO
