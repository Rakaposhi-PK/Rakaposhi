-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spGetAllTransactionType' 
)
   DROP PROCEDURE dbo.spGetAllTransactionType
GO

CREATE PROCEDURE dbo.spGetAllTransactionType
	
AS
	SELECT RecId, [Name], [Description] FROM TRANSTYPE 
	FOR JSON AUTO
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
