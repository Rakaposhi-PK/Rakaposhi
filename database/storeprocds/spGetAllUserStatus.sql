USE [RakaposhiDB]
GO
/****** Object:  StoredProcedure [dbo].[spGetAllUserStatus]    Script Date: 09-Aug-22 8:23:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spGetAllUserStatus]
	
AS
	SELECT RecId,[Status] FROM USERSTATUS
	FOR JSON AUTO

