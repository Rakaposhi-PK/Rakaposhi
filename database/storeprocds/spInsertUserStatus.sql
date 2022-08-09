-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spInsertUserStatus' 
)
   DROP PROCEDURE dbo.spInsertUserStatus
GO

CREATE PROCEDURE dbo.spInsertUserStatus
	@Status nvarchar(20) 
AS
	INSERT INTO USERSTATUS(Status)
	VALUES(@Status) 
	SELECT SCOPE_IDENTITY(); 
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
