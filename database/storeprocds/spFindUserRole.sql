USE [Rakaposhi]
GO
/****** Object:  StoredProcedure [dbo].[spFindUserRole]    Script Date: 12/07/2022 1:11:09 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spFindUserRole]
	@UserRoleID bigint
AS
	SELECT Top 1 UserRoleID, UserRoleName, UserDescription from USERROLE
		Where UserRoleID = @UserRoleID for json Auto, without_array_wrapper;
