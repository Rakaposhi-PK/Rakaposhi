IF EXISTS(select 1 from sys.databases where [name]='RakaposhiDB')
	DROP DATABASE [RakaposhiDB]
GO
USE [master]
GO
CREATE DATABASE [RakaposhiDB]
GO
USE [RakaposhiDB]
GO
/****** Object:  Table [dbo].[USER]    Script Date: 17/07/2022 12:11:26 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nchar](30) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[EmailAddress] [varchar](50) NULL,
	[RoleID] [bigint] NOT NULL,
	[ImageID] [bigint] NOT NULL,
 CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERIMAGE]    Script Date: 17/07/2022 12:11:26 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERIMAGE](
	[ImageID] [bigint] IDENTITY(1,1) NOT NULL,
	[Image] [image] NOT NULL,
 CONSTRAINT [PK_USERIMAGE] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERROLE]    Script Date: 17/07/2022 12:11:26 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERROLE](
	[UserRoleID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserRoleName] [nvarchar](15) NOT NULL,
	[UserDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_USERROLE] PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[USERROLE] ON 
GO
INSERT [dbo].[USERROLE] ([UserRoleID], [UserRoleName], [UserDescription]) VALUES (2, N'Admin', N'This role has alrights')
GO
INSERT [dbo].[USERROLE] ([UserRoleID], [UserRoleName], [UserDescription]) VALUES (10003, N'fake', N'testing')
GO
INSERT [dbo].[USERROLE] ([UserRoleID], [UserRoleName], [UserDescription]) VALUES (10004, N'fake', N'testing3')
GO
SET IDENTITY_INSERT [dbo].[USERROLE] OFF
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD  CONSTRAINT [FK_USER_USERIMAGE] FOREIGN KEY([ImageID])
REFERENCES [dbo].[USERIMAGE] ([ImageID])
GO
ALTER TABLE [dbo].[USER] CHECK CONSTRAINT [FK_USER_USERIMAGE]
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD  CONSTRAINT [FK_USER_USERROLE] FOREIGN KEY([RoleID])
REFERENCES [dbo].[USERROLE] ([UserRoleID])
GO
ALTER TABLE [dbo].[USER] CHECK CONSTRAINT [FK_USER_USERROLE]
GO
/****** Object:  StoredProcedure [dbo].[spFindUserRole]    Script Date: 17/07/2022 12:11:27 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spFindUserRole]
	@UserRoleID bigint
AS
	SELECT Top 1 UserRoleID, UserRoleName, UserDescription from USERROLE
		Where UserRoleID = @UserRoleID for json Auto, without_array_wrapper;
GO
/****** Object:  StoredProcedure [dbo].[spInsertUserRole]    Script Date: 17/07/2022 12:11:27 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spInsertUserRole]
		@UserRoleName nvarchar(15),
		@UserDescription nvarchar(50)
AS
	Insert into USERROLE ([UserRoleName], [UserDescription])
		values (@UserRoleName, @UserDescription) Select SCOPE_IDENTITY();
GO
USE [master]
GO
ALTER DATABASE [RakaposhiDB] SET  READ_WRITE 
GO
