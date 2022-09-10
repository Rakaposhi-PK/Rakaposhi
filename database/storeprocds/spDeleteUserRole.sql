-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spDeleteUserRole' 
)
   DROP PROCEDURE dbo.spDeleteUserRole
GO

CREATE PROCEDURE dbo.spDeleteUserRole
	@RecId bigint
AS
	DELETE FROM USERROLETABLE 
	WHERE RecId = @RecId
	
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE
--GO
