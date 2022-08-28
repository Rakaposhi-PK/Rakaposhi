-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spInsertTransaction' 
)
   DROP PROCEDURE dbo.spInsertTransaction
GO

CREATE PROCEDURE dbo.spInsertTransaction
	@UserId bigint,
	@Transtype bigint,
	@Amount decimal(18,2),
	@Date datetime
AS
	INSERT INTO TRANSTABLE(UserId, Transtype, Amount, [Date])
	VALUES(@UserId, @Transtype, @Amount, @Date) 
	SELECT SCOPE_IDENTITY(); 
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
