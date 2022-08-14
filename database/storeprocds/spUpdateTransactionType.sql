-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spUpdateTransactionType' 
)
   DROP PROCEDURE dbo.spUpdateTransactionType
GO

CREATE PROCEDURE dbo.spUpdateTransactionType
	@RecId bigint,
	@Name nvarchar(20),
	@Description nvarchar(50)
AS
	IF(@RecId IS NOT NULL)
	BEGIN
	UPDATE TRANSTYPE
	SET [Name] = @Name, Description = @Description
	WHERE RecId = @RecId
	END
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO