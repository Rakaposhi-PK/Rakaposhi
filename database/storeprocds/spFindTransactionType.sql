-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spFindTransactionType' 
)
   DROP PROCEDURE dbo.spFindTransactionType
GO

CREATE PROCEDURE dbo.spFindTransactionType
	@RecId bigint
AS
	SELECT Top 1 RecId, Name, Description FROM TRANSTYPE
	WHERE RecId = @RecId FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER;
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
