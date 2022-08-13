-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spUpdateRole' 
)
   DROP PROCEDURE dbo.spUpdateRole
GO

CREATE PROCEDURE dbo.spUpdateRole
	@RecId bigint,
	@Name nvarchar(20),
	@Description nvarchar(50)
AS
	IF(@RecId IS NOT NULL)
	BEGIN
	UPDATE ROLETABLE
	SET [Name] = @Name, Description = @Description
	WHERE RecId = @RecId
	END
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
