USE [RakaposhiDB]
GO
/****** Object:  StoredProcedure [dbo].[spInsertUserRole]    Script Date: 10-Sep-22 9:15:52 PM ******/
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spInsertUserRole' 
)
   DROP PROCEDURE dbo.spInsertUserRole
GO

CREATE PROCEDURE [dbo].[spInsertUserRole]
	@UserId bigint,
	@RoleId bigint
AS
	INSERT INTO USERROLETABLE (UserId, RoleId)
	VALUES (@UserId, @RoleId) SELECT SCOPE_IDENTITY();
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE
--GO
