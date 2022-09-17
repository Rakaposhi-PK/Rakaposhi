-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spGetAllTransaction' 
)
   DROP PROCEDURE dbo.spGetAllTransaction
GO

CREATE PROCEDURE dbo.spGetAllTransaction
	
AS
	SELECT RecId, UserId, Transtype, Amount, [Date] FROM TRANSTABLE
	FOR JSON AUTO
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE 
--GO
