USE [RakaposhiDB]
GO
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spFindUserRole' 
)
   DROP PROCEDURE dbo.spFindUserRole
GO

CREATE PROCEDURE [dbo].[spFindUserRole]
	@RecId bigint
AS
	SELECT Top 1 RecId, UserId, RoleId FROM USERROLETABLE
	WHERE RecId = @RecId FOR JSON AUTO, WITHOUT_ARRAY_WRAPPER;
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE
--GO

