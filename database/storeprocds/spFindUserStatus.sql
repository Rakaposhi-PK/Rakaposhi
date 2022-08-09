-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spFindUserStatus' 
)
   DROP PROCEDURE dbo.spFindUserStatus
GO

CREATE PROCEDURE dbo.spFindUserStatus
	@RecId bigint
AS
	SELECT Top 1 RecId, Status FROM USERSTATUS
	WHERE RecId = @RecId FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER;
--GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
