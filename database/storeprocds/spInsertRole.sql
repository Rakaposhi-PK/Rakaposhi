USE [RakaposhiDB]
GO
/****** Object:  StoredProcedure [dbo].[spInsertRole]    Script Date: 13-Aug-22 10:45:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spInsertRole]
	@Name nvarchar(20),
	@Description nvarchar(50)
AS
	IF (@Name IS NOT NULL)
	BEGIN
	INSERT INTO ROLETABLE(Name,Description)
	VALUES (@Name,@Description)
	SELECT SCOPE_IDENTITY();
	END
