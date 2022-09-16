-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spDeleteTransactionType' 
)
   DROP PROCEDURE dbo.spDeleteTransactionType
GO

CREATE PROCEDURE dbo.spDeleteTransactionType
	@RecId bigint
AS
	IF (@RecId IS NOT NULL)
	BEGIN
	DELETE FROM TRANSTYPE
	WHERE RecId = @RecId
	END
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
