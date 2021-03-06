USE [Rakaposhi]
GO
/****** Object:  StoredProcedure [dbo].[spInsertUserRole]    Script Date: 12/07/2022 1:09:58 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spInsertUserRole]
		@UserRoleName nvarchar(15),
		@UserDescription nvarchar(50)
AS
	Insert into USERROLE ([UserRoleName], [UserDescription])
		values (@UserRoleName, @UserDescription) Select SCOPE_IDENTITY();
