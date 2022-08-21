-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spFindRole' 
)
   DROP PROCEDURE dbo.spFindRole
GO

CREATE PROCEDURE dbo.spFindRole
	@RecId bigint
AS
	SELECT TOP 1 RecId, [Name], [Description] FROM ROLETABLE
	WHERE RecId = @RecId FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
