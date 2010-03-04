IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Projects_Completed]') AND parent_object_id = OBJECT_ID(N'[dbo].[Projects]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Projects_Completed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [DF_Projects_Completed]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Projects_Active]') AND parent_object_id = OBJECT_ID(N'[dbo].[Projects]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Projects_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [DF_Projects_Active]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Projects_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[Projects]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Projects_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [DF_Projects_Deleted]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Projects_Locked]') AND parent_object_id = OBJECT_ID(N'[dbo].[Projects]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Projects_Locked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [DF_Projects_Locked]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ProjectTypes_Active]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectTypes]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ProjectTypes_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProjectTypes] DROP CONSTRAINT [DF_ProjectTypes_Active]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ProjectTypes_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectTypes]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ProjectTypes_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProjectTypes] DROP CONSTRAINT [DF_ProjectTypes_Deleted]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ProjectTypes_Locked]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectTypes]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ProjectTypes_Locked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProjectTypes] DROP CONSTRAINT [DF_ProjectTypes_Locked]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_IsAdmin]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_IsAdmin]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_IsAdmin]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_IsEditor]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_IsEditor]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_IsEditor]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_IsReadOnly]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_IsReadOnly]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_IsReadOnly]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_Active]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_Active]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_Deleted]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_Locked]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_Locked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] DROP CONSTRAINT [DF_Roles_Locked]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Users_Active]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Users_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_Active]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Users_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Users_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_Deleted]
END


End
GO
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Users_Locked]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
Begin
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Users_Locked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [DF_Users_Locked]
END


End
GO
/****** Object:  ForeignKey [FK_ProjectStepData_ProjectStepData]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectStepData_ProjectStepData]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectStepData]'))
ALTER TABLE [dbo].[ProjectStepData] DROP CONSTRAINT [FK_ProjectStepData_ProjectStepData]
GO
/****** Object:  ForeignKey [FK_ProjectStepData_ProjectSteps]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectStepData_ProjectSteps]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectStepData]'))
ALTER TABLE [dbo].[ProjectStepData] DROP CONSTRAINT [FK_ProjectStepData_ProjectSteps]
GO
/****** Object:  ForeignKey [FK_ProjectStepDataDefinition_OPUSSteps]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectStepDataDefinition_OPUSSteps]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectStepDataDefinition]'))
ALTER TABLE [dbo].[ProjectStepDataDefinition] DROP CONSTRAINT [FK_ProjectStepDataDefinition_OPUSSteps]
GO
/****** Object:  ForeignKey [FK_OPLM_UserActivities_Users]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OPLM_UserActivities_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserActivities]'))
ALTER TABLE [dbo].[UserActivities] DROP CONSTRAINT [FK_OPLM_UserActivities_Users]
GO
/****** Object:  ForeignKey [FK_UsersRoles_Roles]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRoles]'))
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UsersRoles_Roles]
GO
/****** Object:  ForeignKey [FK_UsersRoles_Users]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersRoles_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRoles]'))
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UsersRoles_Users]
GO
/****** Object:  Table [dbo].[ProjectStepData]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectStepData]') AND type in (N'U'))
DROP TABLE [dbo].[ProjectStepData]
GO
/****** Object:  Table [dbo].[ProjectStepDataDefinition]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectStepDataDefinition]') AND type in (N'U'))
DROP TABLE [dbo].[ProjectStepDataDefinition]
GO
/****** Object:  Table [dbo].[UserActivities]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserActivities]') AND type in (N'U'))
DROP TABLE [dbo].[UserActivities]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[HistoryData]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HistoryData]') AND type in (N'U'))
DROP TABLE [dbo].[HistoryData]
GO
/****** Object:  Table [dbo].[OPUSSteps]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OPUSSteps]') AND type in (N'U'))
DROP TABLE [dbo].[OPUSSteps]
GO
/****** Object:  Table [dbo].[OPUSStepTypes]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OPUSStepTypes]') AND type in (N'U'))
DROP TABLE [dbo].[OPUSStepTypes]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Projects]') AND type in (N'U'))
DROP TABLE [dbo].[Projects]
GO
/****** Object:  Table [dbo].[ProjectSteps]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectSteps]') AND type in (N'U'))
DROP TABLE [dbo].[ProjectSteps]
GO
/****** Object:  Table [dbo].[ProjectSubmissions]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectSubmissions]') AND type in (N'U'))
DROP TABLE [dbo].[ProjectSubmissions]
GO
/****** Object:  Table [dbo].[ProjectTypes]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectTypes]') AND type in (N'U'))
DROP TABLE [dbo].[ProjectTypes]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 01/10/2010 23:58:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Roles](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](256) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[IsEditor] [bit] NOT NULL,
	[IsReadOnly] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NULL,
	[CreatedByDateTime] [varchar](60) NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectTypes]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectTypes](
	[Id] [bigint] NOT NULL,
	[TypeName] [varchar](255) NOT NULL,
	[WebTitle] [varchar](100) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NOT NULL,
	[CreatedByDateTime] [varchar](60) NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectSubmissions]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectSubmissions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectSubmissions](
	[Id] [bigint] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[ProjectId] [bigint] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NULL,
	[CreatedByDateTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectSubmissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectSteps]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectSteps]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectSteps](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SubmissionId] [bigint] NOT NULL,
	[StepId] [bigint] NULL,
	[ParentStepId] [bigint] NOT NULL,
	[DefinitionId] [bigint] NULL,
	[DataId] [bigint] NULL,
	[SortOrder] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NULL,
	[CreatedByDateTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectSteps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Projects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Projects](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](2000) NOT NULL,
	[ShortName] [varchar](255) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[TypeId] [bigint] NOT NULL,
	[Status] [varchar](1000) NULL,
	[StatusSummary] [varchar](1000) NULL,
	[Explanation] [varchar](max) NULL,
	[ShortDescription] [varchar](max) NULL,
	[FullDescription] [varchar](max) NULL,
	[SoftekId] [bigint] NULL,
	[SubmissionInstruction] [varchar](max) NULL,
	[DetailIntro] [varchar](1000) NULL,
	[Proposal] [varchar](4000) NULL,
	[Contract] [varchar](1000) NULL,
	[Conditions] [varchar](3000) NULL,
	[CareSettings] [varchar](3000) NULL,
	[NPPTopics] [varchar](3000) NULL,
	[Completed] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NOT NULL,
	[CreatedByDateTime] [varchar](60) NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OPUSStepTypes]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OPUSStepTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OPUSStepTypes](
	[Id] [bigint] NOT NULL,
	[TypeName] [varchar](200) NOT NULL,
	[TypeIndicator] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NULL,
	[CreatedByDateTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_OPUSStepTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OPUSSteps]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OPUSSteps]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OPUSSteps](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TypeId] [bigint] NOT NULL,
	[TypeIndicator] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[BeforePeriodDescription] [varchar](8000) NULL,
	[DuringPeriodDescription] [varchar](8000) NULL,
	[AfterPeriodDescription] [varchar](8000) NULL,
	[DetailPage] [varchar](500) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NULL,
	[CreatedByDateTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_OPUSSteps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HistoryData]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HistoryData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[HistoryData](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProjectId] [bigint] NOT NULL,
	[HistoryType] [varchar](50) NOT NULL,
	[FieldName] [varchar](100) NOT NULL,
	[SQLFieldTypeCode] [tinyint] NOT NULL,
	[BeforeValue] [sql_variant] NULL,
	[AfterValue] [sql_variant] NULL,
	[UserId] [bigint] NOT NULL,
	[UserName] [varchar](60) NOT NULL,
	[RecordId] [bigint] NOT NULL,
	[ReasonForChange] [varchar](1000) NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_HistoryData] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IMISUserId] [varchar](60) NULL,
	[IMISMemberType] [varchar](5) NOT NULL,
	[UserName] [varchar](60) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](20) NULL,
	[Title] [varchar](80) NOT NULL,
	[Organization] [varchar](100) NULL,
	[WorkPhone] [varchar](50) NULL,
	[HomePhone] [varchar](50) NULL,
	[City] [varchar](75) NULL,
	[State] [varchar](50) NULL,
	[PrimaryCouncil] [varchar](50) NULL,
	[ContactId] [varchar](50) NULL,
	[RoleId] [bigint] NOT NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NULL,
	[CreatedByDateTime] [varchar](60) NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserRoles](
	[UserId] [bigint] NULL,
	[RoleId] [bigint] NULL
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND name = N'IX_UserRoles_UserRoleShouldBeUnique')
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserRoles_UserRoleShouldBeUnique] ON [dbo].[UserRoles] 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserActivities]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserActivities]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserActivities](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[ActivityType] [int] NULL,
	[ActivityTime] [datetime] NULL,
	[IPAddress] [varchar](50) NULL,
	[RequestedURL] [varchar](400) NULL,
	[SessionId] [varchar](100) NULL,
	[RefUrl] [varchar](400) NULL,
	[Browser] [varchar](100) NULL,
	[ShortMessage] [varchar](2000) NULL,
	[LongMessage] [varchar](8000) NULL,
 CONSTRAINT [PK_UserActivities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectStepDataDefinition]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectStepDataDefinition]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectStepDataDefinition](
	[Id] [bigint] NOT NULL,
	[StepId] [bigint] NULL,
	[FieldName] [varchar](100) NULL,
	[WebCaption] [varchar](200) NULL,
	[DataType] [varchar](50) NULL,
	[Required] [bit] NULL,
	[DefaultValue] [varchar](max) NULL,
	[MinValue] [varchar](max) NULL,
	[MaxValue] [varchar](max) NULL,
	[ControlType] [varchar](300) NULL,
	[SelectionOptions] [varchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NULL,
	[CreatedByDateTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectStepDataDefinition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectStepData]    Script Date: 01/10/2010 23:58:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectStepData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProjectStepData](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DefinitionId] [bigint] NULL,
	[ProjectStepId] [bigint] NULL,
	[Value] [varchar](max) NULL,
	[Active] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[Locked] [bit] NOT NULL,
	[CreatedBy] [varchar](60) NULL,
	[CreatedByDateTime] [datetime] NOT NULL,
	[LastModifiedBy] [varchar](60) NOT NULL,
	[LastModifiedByDateTime] [datetime] NOT NULL,
	[DatetimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectStepData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Projects_Completed]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Projects_Completed]') AND parent_object_id = OBJECT_ID(N'[dbo].[Projects]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Projects_Completed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_Completed]  DEFAULT ((1)) FOR [Completed]
END


End
GO
/****** Object:  Default [DF_Projects_Active]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Projects_Active]') AND parent_object_id = OBJECT_ID(N'[dbo].[Projects]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Projects_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_Active]  DEFAULT ((1)) FOR [Active]
END


End
GO
/****** Object:  Default [DF_Projects_Deleted]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Projects_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[Projects]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Projects_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_Deleted]  DEFAULT ((0)) FOR [Deleted]
END


End
GO
/****** Object:  Default [DF_Projects_Locked]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Projects_Locked]') AND parent_object_id = OBJECT_ID(N'[dbo].[Projects]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Projects_Locked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF_Projects_Locked]  DEFAULT ((0)) FOR [Locked]
END


End
GO
/****** Object:  Default [DF_ProjectTypes_Active]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ProjectTypes_Active]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectTypes]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ProjectTypes_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProjectTypes] ADD  CONSTRAINT [DF_ProjectTypes_Active]  DEFAULT ((1)) FOR [Active]
END


End
GO
/****** Object:  Default [DF_ProjectTypes_Deleted]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ProjectTypes_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectTypes]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ProjectTypes_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProjectTypes] ADD  CONSTRAINT [DF_ProjectTypes_Deleted]  DEFAULT ((0)) FOR [Deleted]
END


End
GO
/****** Object:  Default [DF_ProjectTypes_Locked]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_ProjectTypes_Locked]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectTypes]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_ProjectTypes_Locked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ProjectTypes] ADD  CONSTRAINT [DF_ProjectTypes_Locked]  DEFAULT ((0)) FOR [Locked]
END


End
GO
/****** Object:  Default [DF_Roles_IsAdmin]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_IsAdmin]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_IsAdmin]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
END


End
GO
/****** Object:  Default [DF_Roles_IsEditor]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_IsEditor]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_IsEditor]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_IsEditor]  DEFAULT ((0)) FOR [IsEditor]
END


End
GO
/****** Object:  Default [DF_Roles_IsReadOnly]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_IsReadOnly]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_IsReadOnly]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_IsReadOnly]  DEFAULT ((0)) FOR [IsReadOnly]
END


End
GO
/****** Object:  Default [DF_Roles_Active]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_Active]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_Active]  DEFAULT ((1)) FOR [Active]
END


End
GO
/****** Object:  Default [DF_Roles_Deleted]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_Deleted]  DEFAULT ((0)) FOR [Deleted]
END


End
GO
/****** Object:  Default [DF_Roles_Locked]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Roles_Locked]') AND parent_object_id = OBJECT_ID(N'[dbo].[Roles]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Roles_Locked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_Locked]  DEFAULT ((0)) FOR [Locked]
END


End
GO
/****** Object:  Default [DF_Users_Active]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Users_Active]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Users_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Active]  DEFAULT ((1)) FOR [Active]
END


End
GO
/****** Object:  Default [DF_Users_Deleted]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Users_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Users_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Deleted]  DEFAULT ((0)) FOR [Deleted]
END


End
GO
/****** Object:  Default [DF_Users_Locked]    Script Date: 01/10/2010 23:58:33 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_Users_Locked]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
Begin
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Users_Locked]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Locked]  DEFAULT ((0)) FOR [Locked]
END


End
GO
/****** Object:  ForeignKey [FK_ProjectStepData_ProjectStepData]    Script Date: 01/10/2010 23:58:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectStepData_ProjectStepData]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectStepData]'))
ALTER TABLE [dbo].[ProjectStepData]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStepData_ProjectStepData] FOREIGN KEY([DefinitionId])
REFERENCES [dbo].[ProjectStepDataDefinition] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectStepData_ProjectStepData]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectStepData]'))
ALTER TABLE [dbo].[ProjectStepData] CHECK CONSTRAINT [FK_ProjectStepData_ProjectStepData]
GO
/****** Object:  ForeignKey [FK_ProjectStepData_ProjectSteps]    Script Date: 01/10/2010 23:58:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectStepData_ProjectSteps]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectStepData]'))
ALTER TABLE [dbo].[ProjectStepData]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStepData_ProjectSteps] FOREIGN KEY([ProjectStepId])
REFERENCES [dbo].[ProjectSteps] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectStepData_ProjectSteps]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectStepData]'))
ALTER TABLE [dbo].[ProjectStepData] CHECK CONSTRAINT [FK_ProjectStepData_ProjectSteps]
GO
/****** Object:  ForeignKey [FK_ProjectStepDataDefinition_OPUSSteps]    Script Date: 01/10/2010 23:58:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectStepDataDefinition_OPUSSteps]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectStepDataDefinition]'))
ALTER TABLE [dbo].[ProjectStepDataDefinition]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStepDataDefinition_OPUSSteps] FOREIGN KEY([StepId])
REFERENCES [dbo].[OPUSSteps] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ProjectStepDataDefinition_OPUSSteps]') AND parent_object_id = OBJECT_ID(N'[dbo].[ProjectStepDataDefinition]'))
ALTER TABLE [dbo].[ProjectStepDataDefinition] CHECK CONSTRAINT [FK_ProjectStepDataDefinition_OPUSSteps]
GO
/****** Object:  ForeignKey [FK_OPLM_UserActivities_Users]    Script Date: 01/10/2010 23:58:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OPLM_UserActivities_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserActivities]'))
ALTER TABLE [dbo].[UserActivities]  WITH CHECK ADD  CONSTRAINT [FK_OPLM_UserActivities_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_OPLM_UserActivities_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserActivities]'))
ALTER TABLE [dbo].[UserActivities] CHECK CONSTRAINT [FK_OPLM_UserActivities_Users]
GO
/****** Object:  ForeignKey [FK_UsersRoles_Roles]    Script Date: 01/10/2010 23:58:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRoles]'))
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRoles]'))
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UsersRoles_Roles]
GO
/****** Object:  ForeignKey [FK_UsersRoles_Users]    Script Date: 01/10/2010 23:58:33 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersRoles_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRoles]'))
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UsersRoles_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UsersRoles_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRoles]'))
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UsersRoles_Users]
GO
