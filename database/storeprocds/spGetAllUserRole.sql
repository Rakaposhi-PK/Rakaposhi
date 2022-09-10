USE [RakaposhiDB]
GO

IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spGetAllUserRole' 
)
   DROP PROCEDURE dbo.spGetAllUserRole
GO

CREATE PROCEDURE [dbo].[spGetAllUserRole]
	
AS
	SELECT RecId, UserId, RoleId FROM USERROLETABLE
	FOR JSON AUTO
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE
--GO
