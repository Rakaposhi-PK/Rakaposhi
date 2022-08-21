-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spInsertTransactionType' 
)
   DROP PROCEDURE dbo.spInsertTransactionType
GO

CREATE PROCEDURE dbo.spInsertTransactionType
	@Name nvarchar(10),
	@Description nvarchar(50)
AS
	IF (@Name IS NOT NULL)
	BEGIN
	INSERT INTO TRANSTYPE([Name],[Description])
	VALUES (@Name,@Description)
	SELECT SCOPE_IDENTITY();
	END
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
