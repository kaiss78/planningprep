IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = '[dbo].[Users]')
	BEGIN
		DROP  Table [dbo].[Users]
	END
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IMISUserId] [varchar](60) NULL,
	[IMISMemberType] [varchar](5) NOT NULL,
	[UserName] [varchar](60) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](20) NULL,	
	[Title] [varchar](80) NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NULL,
	[CreatedByDateTime] [varchar](60) NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ( [Id] ASC )
 WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) 
ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/*
GRANT SELECT ON Table_Name TO PUBLIC

GO
*/

--SET IDENTITY_INSERT [dbo].[Users] ON
--INSERT [dbo].[Users] ([Id], [IMISUserId], [IMISMemberType], [UserName], [Email], [FirstName], [LastName], [Title], [Organization], [WorkPhone], [HomePhone], [City], [State], [PrimaryCouncil], [ContactId], [RoleId], [Active], [Deleted], [Locked], [CreatedBy], [CreatedByDateTime], [LastModifiedBy], [LastModifiedByDateTime], [DatetimeStamp]) VALUES (1, N'100785', N'Admin', N'jduffus', N'jason@Panth.com', N'Jason', N'Duffus', N'Senior Software Architect', NULL, NULL, NULL, N'Washington', N'DC', NULL, NULL, 1, 1, 0, 0, N'jduffus', N'Feb 16 2010  4:51PM', N'jduffus', CAST(0x00009D1F0115D9F4 AS DateTime), CAST(0x00009D1F0115D9F4 AS DateTime))
--INSERT [dbo].[Users] ([Id], [IMISUserId], [IMISMemberType], [UserName], [Email], [FirstName], [LastName], [Title], [Organization], [WorkPhone], [HomePhone], [City], [State], [PrimaryCouncil], [ContactId], [RoleId], [Active], [Deleted], [Locked], [CreatedBy], [CreatedByDateTime], [LastModifiedBy], [LastModifiedByDateTime], [DatetimeStamp]) VALUES (2, N'100786', N'staff', N'bobama', N'jason@Panth.com', N'Barrack', N'Obama', N'President', NULL, NULL, NULL, N'Washington', N'DC', NULL, NULL, 2, 1, 0, 0, N'jduffus', N'Feb 16 2010  4:51PM', N'jduffus', CAST(0x00009D1F0115D9F4 AS DateTime), CAST(0x00009D1F0115D9F4 AS DateTime))
--INSERT [dbo].[Users] ([Id], [IMISUserId], [IMISMemberType], [UserName], [Email], [FirstName], [LastName], [Title], [Organization], [WorkPhone], [HomePhone], [City], [State], [PrimaryCouncil], [ContactId], [RoleId], [Active], [Deleted], [Locked], [CreatedBy], [CreatedByDateTime], [LastModifiedBy], [LastModifiedByDateTime], [DatetimeStamp]) VALUES (3, N'100787', N'staff', N'mmouse', N'jason@Panth.com', N'Mickey', N'Mouse', N'Manager', NULL, NULL, NULL, N'Washington', N'DC', NULL, NULL, 3, 1, 0, 0, N'jduffus', N'Feb 16 2010  4:51PM', N'jduffus', CAST(0x00009D1F0115D9F4 AS DateTime), CAST(0x00009D1F0115D9F4 AS DateTime))
--INSERT [dbo].[Users] ([Id], [IMISUserId], [IMISMemberType], [UserName], [Email], [FirstName], [LastName], [Title], [Organization], [WorkPhone], [HomePhone], [City], [State], [PrimaryCouncil], [ContactId], [RoleId], [Active], [Deleted], [Locked], [CreatedBy], [CreatedByDateTime], [LastModifiedBy], [LastModifiedByDateTime], [DatetimeStamp]) VALUES (4, N'100789', N'staff', N'sjobs', N'jason@Panth.com', N'Steve', N'Jobs', N'CEO', NULL, NULL, NULL, N'Washington', N'DC', NULL, NULL, 4, 1, 0, 0, N'jduffus', N'Feb 16 2010  4:51PM', N'jduffus', CAST(0x00009D1F0115D9F4 AS DateTime), CAST(0x00009D1F0115D9F4 AS DateTime))
--INSERT [dbo].[Users] ([Id], [IMISUserId], [IMISMemberType], [UserName], [Email], [FirstName], [LastName], [Title], [Organization], [WorkPhone], [HomePhone], [City], [State], [PrimaryCouncil], [ContactId], [RoleId], [Active], [Deleted], [Locked], [CreatedBy], [CreatedByDateTime], [LastModifiedBy], [LastModifiedByDateTime], [DatetimeStamp]) VALUES (5, N'100790', N'staff', N'bgates', N'jason@Panth.com', N'Bill', N'Gates', N'Chairman', NULL, NULL, NULL, N'Washington', N'DC', NULL, NULL, 3, 1, 0, 0, N'jduffus', N'Feb 16 2010  4:51PM', N'jduffus', CAST(0x00009D1F0115D9F4 AS DateTime), CAST(0x00009D1F0115D9F4 AS DateTime))
--SET IDENTITY_INSERT [dbo].[Users] OFF
