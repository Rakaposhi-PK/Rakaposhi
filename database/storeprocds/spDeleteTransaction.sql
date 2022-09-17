-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spDeleteTransaction' 
)
   DROP PROCEDURE dbo.spDeleteTransaction
GO

CREATE PROCEDURE dbo.spDeleteTransaction
	@RecId bigint
AS
	DELETE FROM TRANSTABLE
	WHERE RecId = @RecId
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
