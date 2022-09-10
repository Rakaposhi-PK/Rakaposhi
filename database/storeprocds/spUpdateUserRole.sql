-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'dbo.spUpdateUserRole' 
)
   DROP PROCEDURE dbo.spUpdateUserRole
GO

CREATE OR ALTER PROCEDURE dbo.spUpdateUserRole
	@RecId bigint,
	@UserId bigint,
	@RoleId bigint

AS
	UPDATE USERROLETABLE
	SET UserId = @UserId, RoleId = @RoleId WHERE RecId = @RecId
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
