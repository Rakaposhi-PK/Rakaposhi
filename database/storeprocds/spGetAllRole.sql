-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spGetAllRole' 
)
   DROP PROCEDURE dbo.spGetAllRole
GO

CREATE PROCEDURE dbo.spGetAllRole
	
AS
	SELECT RecId, Name, Description FROM ROLETABLE 
	FOR JSON AUTO
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
