-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spUpdateTransaction' 
)
   DROP PROCEDURE dbo.spUpdateTransaction
GO

CREATE PROCEDURE dbo.spUpdateTransaction
	@RecId  bigint,
	@UserId bigint,
	@Transtype bigint,
	@Amount decimal(18,2),
	@Date datetime
AS
	UPDATE TRANSTABLE 
	SET UserId = @UserId, Transtype = @Transtype, Amount = @Amount, [Date] = @Date WHERE RecID = @RecId
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
