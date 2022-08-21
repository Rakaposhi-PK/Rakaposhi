-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spDeleteRole' 
)
   DROP PROCEDURE dbo.spDeleteRole
GO

CREATE PROCEDURE dbo.spDeleteRole
	@RecId bigint 
AS

	IF (@RecId IS NOT NULL)
	BEGIN
	DELETE FROM ROLETABLE
	WHERE RecId = @RecId
	END
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
