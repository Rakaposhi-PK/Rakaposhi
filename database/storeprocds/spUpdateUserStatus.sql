-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo' 
     AND SPECIFIC_NAME = N'spUpdateUserStatus' 
)
   DROP PROCEDURE dbo.spUpdateUserStatus
GO

CREATE PROCEDURE dbo.spUpdateUserStatus
	@RecId bigint ,
	@Status nvarchar(20)
AS
	UPDATE USERSTATUS 
	SET [Status] = @Status WHERE RecID = @RecId
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
