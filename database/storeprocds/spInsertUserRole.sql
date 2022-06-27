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
		@Role nvarchar(15),
		@Description nvarchar(50)
AS
	Insert into USERROLE ([Role], [Description])
		values (@Role, @Description);
GO

-- =============================================
-- Example to execute the stored procedure
-- =============================================
--EXECUTE dbo.spInsertUserRole 'Admin','This role has alrights'
--GO
