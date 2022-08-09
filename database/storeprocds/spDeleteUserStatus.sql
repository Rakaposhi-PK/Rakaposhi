-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spDeleteUserStatus' 
)
   DROP PROCEDURE dbo.spDeleteUserStatus
GO

CREATE PROCEDURE dbo.spDeleteUserStatus
	@RecId bigint
AS
	DELETE FROM USERSTATUS 
	WHERE RecId = @RecId
	
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE
--GO
