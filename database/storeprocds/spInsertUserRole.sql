-- =============================================
-- Create basic stored procedure template
-- =============================================

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spInsertUserRole' 
)
   DROP PROCEDURE dbo.spInsertUserRole
GO

CREATE PROCEDURE dbo.spInsertUserRole
		@UserRole nvarchar(15),
		@UserDescription nvarchar(50)
AS
	Insert into USERROLE ([UserRole], [UserDescription])
		values (@UserRole, @UserDescription) Select SCOPE_IDENTITY();
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE dbo.spInsertUserRole 'Admin','This role has alrights'
--GO