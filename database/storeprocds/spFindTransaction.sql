-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spFindTransaction' 
)
   DROP PROCEDURE dbo.spFindTransaction
GO

CREATE PROCEDURE dbo.spFindTransaction
	@RecId bigint
AS
	SELECT Top 1 RecId, UserId, Transtype, Amount, [Date] FROM TRANSTABLE
	WHERE RecId = @RecId FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER;

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE
--GO
