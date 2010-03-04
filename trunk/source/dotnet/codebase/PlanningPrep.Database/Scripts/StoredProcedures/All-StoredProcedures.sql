/****** Object:  StoredProcedure [dbo].[spUserActivitySet]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserActivitySet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserActivitySet]
GO
/****** Object:  StoredProcedure [dbo].[spUserRoleSet]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserRoleSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserRoleSet]
GO
/****** Object:  StoredProcedure [dbo].[spUserSet]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserSet]
GO
/****** Object:  StoredProcedure [dbo].[spCallForIntentStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCallForIntentStepGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spCallForIntentStepGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spCallForNominationStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCallForNominationStepGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spCallForNominationStepGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spCallForStandardStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCallForStandardStepGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spCallForStandardStepGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spConsensusReviewStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spConsensusReviewStepGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spConsensusReviewStepGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spCustomStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCustomStepGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spCustomStepGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spHistoryDataSet]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spHistoryDataSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spHistoryDataSet]
GO
/****** Object:  StoredProcedure [dbo].[spNominationPeriodStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spNominationPeriodStepGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spNominationPeriodStepGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spOPUSStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spOPUSStepGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spOPUSStepGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spOPUSStepGetById]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spOPUSStepGetById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spOPUSStepGetById]
GO
/****** Object:  StoredProcedure [dbo].[spOPUSStepSet]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spOPUSStepSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spOPUSStepSet]
GO
/****** Object:  StoredProcedure [dbo].[spOPUSStepsGetAllByProjectStepId]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spOPUSStepsGetAllByProjectStepId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spOPUSStepsGetAllByProjectStepId]
GO
/****** Object:  StoredProcedure [dbo].[spProjectGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spProjectGetById]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectGetById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectGetById]
GO
/****** Object:  StoredProcedure [dbo].[spProjectSet]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectSet]
GO
/****** Object:  StoredProcedure [dbo].[spProjectStepsGetAllByProjectId]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectStepsGetAllByProjectId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectStepsGetAllByProjectId]
GO
/****** Object:  StoredProcedure [dbo].[spProjectStepsGetAllBySubmissionId]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectStepsGetAllBySubmissionId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectStepsGetAllBySubmissionId]
GO
/****** Object:  StoredProcedure [dbo].[spProjectTypeSet]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectTypeSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectTypeSet]
GO
/****** Object:  StoredProcedure [dbo].[spRoleSet]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRoleSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRoleSet]
GO
/****** Object:  StoredProcedure [dbo].[spRosterCommentingPeriodStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRosterCommentingPeriodStepGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRosterCommentingPeriodStepGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spSubmissionPeriodStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSubmissionPeriodStepGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spSubmissionPeriodStepGetAll]
GO
/****** Object:  StoredProcedure [dbo].[spSubmissionPeriodStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spSubmissionPeriodStepGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spSubmissionPeriodStepGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll SubmissionPeriod Steps from the OPUSSteps table 
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.TypeIndicator = 7 
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spRosterCommentingPeriodStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRosterCommentingPeriodStepGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spRosterCommentingPeriodStepGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll RosterCommentingPeriod Steps from the OPUSSteps table 
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.TypeIndicator = 6 
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spRoleSet]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRoleSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spRoleSet] 
	 @Id bigint
	, @Name varchar(50) 
	, @Description varchar(256) 
	, @IsAdmin bit
	, @Active bit
	, @Deleted bit
	, @Locked bit
	, @CreatedBy varchar(60) 
	, @CreatedByDateTime varchar(60) 
	, @LastModifiedBy varchar(60) 
	, @LastModifiedByDateTime datetime
	, @DatetimeStamp datetime

As
Begin
-- =============================================
-- Author:		[Developer Name] (Pantheon Inc.)
-- Create date: 1/5/2010 11:53:51 PM
-- Description: Set Into Table Roles
-- =============================================
-- spRolesSet ...........
		IF (@Id >0)
		Begin
			Update [dbo].[Roles]
				 Set [Name]= @Name
				, [Description]= @Description
				, [IsAdmin]= @IsAdmin
				, [Active]= @Active
				, [Deleted]= @Deleted
				, [Locked]= @Locked
				, [CreatedBy]= @CreatedBy
				, [CreatedByDateTime]= @CreatedByDateTime
				, [LastModifiedBy]= @LastModifiedBy
				, [LastModifiedByDateTime]= @LastModifiedByDateTime
				, [DatetimeStamp]= @DatetimeStamp
				 
			 Where [Id]= @Id
	End
	Else
	Begin
		Insert Into [dbo].[Roles]
			( [Name]
			, [Description]
			, [IsAdmin]
			, [Active]
			, [Deleted]
			, [Locked]
			, [CreatedBy]
			, [CreatedByDateTime]
			, [LastModifiedBy]
			, [LastModifiedByDateTime]
			, [DatetimeStamp]
			 ) 
		 VALUES 
			( @Name
			, @Description
			, @IsAdmin
			, @Active
			, @Deleted
			, @Locked
			, @CreatedBy
			, @CreatedByDateTime
			, @LastModifiedBy
			, @LastModifiedByDateTime
			, @DatetimeStamp
			 ) 
		 
		Set @Id= Scope_Identity()
	End
 
 Select @Id as Id 
End' 
END
GO
/****** Object:  StoredProcedure [dbo].[spProjectTypeSet]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectTypeSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spProjectTypeSet] 
	 @Id bigint
	, @TypeName varchar(255) 
	, @WebTitle varchar(100) 
	, @Active bit
	, @Deleted bit
	, @Locked bit
	, @CreatedBy varchar(60) 
	, @CreatedByDateTime varchar(60) 
	, @LastModifiedBy varchar(60) 
	, @LastModifiedByDateTime datetime
	, @DatetimeStamp datetime

As
Begin
-- =============================================
-- Author:		[Developer Name] (Pantheon Inc.)
-- Create date: 1/5/2010 11:52:38 PM
-- Description: Set Into Table ProjectTypes
-- =============================================
-- spProjectTypesSet ...........
		IF (@Id >0)
		Begin
			Update [dbo].[ProjectTypes]
				 Set [TypeName]= @TypeName
				, [WebTitle]= @WebTitle
				, [Active]= @Active
				, [Deleted]= @Deleted
				, [Locked]= @Locked
				, [CreatedBy]= @CreatedBy
				, [CreatedByDateTime]= @CreatedByDateTime
				, [LastModifiedBy]= @LastModifiedBy
				, [LastModifiedByDateTime]= @LastModifiedByDateTime
				, [DatetimeStamp]= @DatetimeStamp
				 
			 Where [Id]= @Id
	End
	Else
	Begin
		Insert Into [dbo].[ProjectTypes]
			( [TypeName]
			, [WebTitle]
			, [Active]
			, [Deleted]
			, [Locked]
			, [CreatedBy]
			, [CreatedByDateTime]
			, [LastModifiedBy]
			, [LastModifiedByDateTime]
			, [DatetimeStamp]
			 ) 
		 VALUES 
			( @TypeName
			, @WebTitle
			, @Active
			, @Deleted
			, @Locked
			, @CreatedBy
			, @CreatedByDateTime
			, @LastModifiedBy
			, @LastModifiedByDateTime
			, @DatetimeStamp
			 ) 
		 
		Set @Id= Scope_Identity()
	End
 
 Select @Id as Id 
End
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spProjectStepsGetAllBySubmissionId]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectStepsGetAllBySubmissionId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spProjectStepsGetAllBySubmissionId] 
	@SubmissionId INT
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll ProjectSteps by ProjectSubmission
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[ProjectSteps] tab (NOLOCK)
		WHERE tab.SubmissionId = @SubmissionId AND tab.[Deleted] = 0 
		ORDER BY tab.[Id] DESC, ISNULL(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spProjectStepsGetAllByProjectId]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectStepsGetAllByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spProjectStepsGetAllByProjectId] 
	@ProjectId INT
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll ProjectSteps by project Id
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[ProjectSteps] tab (NOLOCK) 
			INNER JOIN [dbo].[ProjectSubmissions] ps (NOLOCK) ON ps.Id = tab.SubmissionId AND ps.Deleted = 0
		WHERE ps.ProjectId = @ProjectId AND tab.[Deleted] = 0 
		ORDER BY tab.[Id] DESC, ISNULL(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spProjectSet]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spProjectSet] 
	 @Id bigint
	, @Name varchar(2000) 
	, @ShortName varchar(255) 
	, @StartDate datetime
	, @EndDate datetime
	, @TypeId bigint
	, @Status varchar(1000) 
	, @StatusSummary varchar(1000) 
	, @Explanation varchar (max)
	, @ShortDescription varchar (max)
	, @FullDescription varchar (max)
	, @SoftekId bigint
	, @SubmissionInstruction varchar (max)
	, @DetailIntro varchar(1000) 
	, @Proposal varchar(4000) 
	, @Contract varchar(1000) 
	, @Conditions varchar(3000) 
	, @CareSettings varchar(3000) 
	, @NPPTopics varchar(3000) 
	, @Completed bit
	, @Active bit
	, @Deleted bit
	, @Locked bit
	, @CreatedBy varchar(60) 
	, @CreatedByDateTime varchar(60) 
	, @LastModifiedBy varchar(60) 
	, @LastModifiedByDateTime datetime
	, @DatetimeStamp datetime
As
Begin
-- =============================================
-- Author:		[Developer Name] (Pantheon Inc.)
-- Create date: 1/5/2010 11:35:35 PM
-- Description: Set Into Table Projects
-- =============================================
-- spProjectsSet ...........
		IF (@Id >0)
		Begin
			Update [dbo].[Projects]
				 Set [Name]= @Name
				, [ShortName]= @ShortName
				, [StartDate]= @StartDate
				, [EndDate]= @EndDate
				, [TypeId]= @TypeId
				, [Status]= @Status
				, [StatusSummary]= @StatusSummary
				, [Explanation]= @Explanation
				, [ShortDescription]= @ShortDescription
				, [FullDescription]= @FullDescription
				, [SoftekId]= @SoftekId
				, [SubmissionInstruction]= @SubmissionInstruction
				, [DetailIntro]= @DetailIntro
				, [Proposal]= @Proposal
				, [Contract]= @Contract
				, [Conditions]= @Conditions
				, [CareSettings]= @CareSettings
				, [NPPTopics]= @NPPTopics
				, [Completed]= @Completed
				, [Active]= @Active
				, [Deleted]= @Deleted
				, [Locked]= @Locked
				, [CreatedBy]= @CreatedBy
				, [CreatedByDateTime]= @CreatedByDateTime
				, [LastModifiedBy]= @LastModifiedBy
				, [LastModifiedByDateTime]= @LastModifiedByDateTime
				, [DatetimeStamp]= @DatetimeStamp
				 
			 Where [Id]= @Id
	End
	Else
	Begin
		Insert Into [dbo].[Projects]
			( [Name]
			, [ShortName]
			, [StartDate]
			, [EndDate]
			, [TypeId]
			, [Status]
			, [StatusSummary]
			, [Explanation]
			, [ShortDescription]
			, [FullDescription]
			, [SoftekId]
			, [SubmissionInstruction]
			, [DetailIntro]
			, [Proposal]
			, [Contract]
			, [Conditions]
			, [CareSettings]
			, [NPPTopics]
			, [Completed]
			, [Active]
			, [Deleted]
			, [Locked]
			, [CreatedBy]
			, [CreatedByDateTime]
			, [LastModifiedBy]
			, [LastModifiedByDateTime]
			, [DatetimeStamp]
			 ) 
		 VALUES 
			( @Name
			, @ShortName
			, @StartDate
			, @EndDate
			, @TypeId
			, @Status
			, @StatusSummary
			, @Explanation
			, @ShortDescription
			, @FullDescription
			, @SoftekId
			, @SubmissionInstruction
			, @DetailIntro
			, @Proposal
			, @Contract
			, @Conditions
			, @CareSettings
			, @NPPTopics
			, @Completed
			, @Active
			, @Deleted
			, @Locked
			, @CreatedBy
			, @CreatedByDateTime
			, @LastModifiedBy
			, @LastModifiedByDateTime
			, @DatetimeStamp
			 ) 
		 
		Set @Id= Scope_Identity()
	End
 
 Select @Id as Id 
End
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spProjectGetById]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectGetById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spProjectGetById] 
	@Id bigint
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/6/2010 12:53:28 AM
-- Description: GetById Into Table Projects
-- =============================================
-- spProjectsGetById ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[Projects] tab (NOLOCK)
		WHERE tab.[Id]=@ID 
		  AND tab.[Deleted] = 0
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spProjectGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spProjectGetAll] 
	@Id bigint
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/9/2010 7:34:55 PM
-- Description: GetAll from Projects table
-- =============================================
-- spProjectsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[Projects] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.[Active] = 1
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spOPUSStepsGetAllByProjectStepId]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spOPUSStepsGetAllByProjectStepId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spOPUSStepsGetAllByProjectStepId] 
	@ProjectStepId INT
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll OPUSSteps by project step Id
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK) 
			INNER JOIN [dbo].[ProjectSteps] ps (NOLOCK) ON ps.StepId = tab.Id AND ps.Deleted = 0
		WHERE ps.Id = @ProjectStepId AND tab.[Deleted] = 0 
		ORDER BY tab.[Id] DESC, ISNULL(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spOPUSStepSet]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spOPUSStepSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spOPUSStepSet] 
	 @Id bigint
	, @TypeId bigint
	, @TypeIndicator int
	, @Name varchar(200) 
	, @StartDate datetime
	, @EndDate datetime
	, @BeforePeriodDescription varchar(8000) 
	, @DuringPeriodDescription varchar(8000) 
	, @AfterPeriodDescription varchar(8000) 
	, @DetailPage varchar(500) 
	, @Active bit
	, @Deleted bit
	, @Locked bit
	, @CreatedBy varchar(60) 
	, @CreatedByDateTime datetime
	, @LastModifiedBy varchar(60) 
	, @LastModifiedByDateTime datetime
	, @DatetimeStamp datetime
As
-- =============================================
-- Author:		[Developer Name] (Pantheon Inc.)
-- Create date: 1/10/2010 9:49:28 PM
-- Description: Set Into Table OPUSSteps
-- =============================================
-- spOPUSStepsSet ...........
Begin
		IF (@Id >0)
		Begin
			Update [dbo].[OPUSSteps]
				 Set [TypeId]= @TypeId
				, [TypeIndicator]= @TypeIndicator
				, [Name]= @Name
				, [StartDate]= @StartDate
				, [EndDate]= @EndDate
				, [BeforePeriodDescription]= @BeforePeriodDescription
				, [DuringPeriodDescription]= @DuringPeriodDescription
				, [AfterPeriodDescription]= @AfterPeriodDescription
				, [DetailPage]= @DetailPage
				, [Active]= @Active
				, [Deleted]= @Deleted
				, [Locked]= @Locked
				, [CreatedBy]= @CreatedBy
				, [CreatedByDateTime]= @CreatedByDateTime
				, [LastModifiedBy]= @LastModifiedBy
				, [LastModifiedByDateTime]= @LastModifiedByDateTime
				, [DatetimeStamp]= @DatetimeStamp
				 
			 Where [Id]= @Id
	End
	Else
	Begin
		Insert Into [dbo].[OPUSSteps]
			( [TypeId]
			, [TypeIndicator]
			, [Name]
			, [StartDate]
			, [EndDate]
			, [BeforePeriodDescription]
			, [DuringPeriodDescription]
			, [AfterPeriodDescription]
			, [DetailPage]
			, [Active]
			, [Deleted]
			, [Locked]
			, [CreatedBy]
			, [CreatedByDateTime]
			, [LastModifiedBy]
			, [LastModifiedByDateTime]
			, [DatetimeStamp]
			 ) 
		 VALUES 
			( @TypeId
			, @TypeIndicator
			, @Name
			, @StartDate
			, @EndDate
			, @BeforePeriodDescription
			, @DuringPeriodDescription
			, @AfterPeriodDescription
			, @DetailPage
			, @Active
			, @Deleted
			, @Locked
			, @CreatedBy
			, @CreatedByDateTime
			, @LastModifiedBy
			, @LastModifiedByDateTime
			, @DatetimeStamp
			 ) 
		 
		Set @Id= Scope_Identity()
	End
 
 Select @Id as Id 
End' 
END
GO
/****** Object:  StoredProcedure [dbo].[spOPUSStepGetById]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spOPUSStepGetById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spOPUSStepGetById] 
	@Id bigint
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:47:38 PM
-- Description: GetById Into Table OPUSSteps
-- =============================================
-- spOPUSStepsGetById ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Id]=@ID 
		  AND tab.[Deleted] = 0
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spOPUSStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spOPUSStepGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spOPUSStepGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll Into Table OPUSSteps
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spNominationPeriodStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spNominationPeriodStepGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spNominationPeriodStepGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll NominationPeriod Steps from the OPUSSteps table 
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.TypeIndicator = 5 
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spHistoryDataSet]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spHistoryDataSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spHistoryDataSet] 
	 @id bigint
	, @ProjectId bigint
	, @HistoryType varchar(50) 
	, @FieldName varchar(100) 
	, @SQLFieldTypeCode tinyint
	, @BeforeValue sql_variant
	, @AfterValue sql_variant
	, @UserId bigint
	, @UserName varchar(60) 
	, @RecordId bigint
	, @ReasonForChange varchar(1000) 
	, @DatetimeStamp datetime

As
Begin
-- =============================================
-- Author:		[Developer Name] (Pantheon Inc.)
-- Create date: 1/5/2010 11:50:58 PM
-- Description: Set Into Table HistoryData
-- =============================================
-- spHistoryDataSet ...........
		IF (@id >0)
		Begin
			Update [dbo].[HistoryData]
				 Set [ProjectId]= @ProjectId
				, [HistoryType]= @HistoryType
				, [FieldName]= @FieldName
				, [SQLFieldTypeCode]= @SQLFieldTypeCode
				, [BeforeValue]= @BeforeValue
				, [AfterValue]= @AfterValue
				, [UserId]= @UserId
				, [UserName]= @UserName
				, [RecordId]= @RecordId
				, [ReasonForChange]= @ReasonForChange
				, [DatetimeStamp]= @DatetimeStamp
				 
			 Where [id]= @id
	End
	Else
	Begin
		Insert Into [dbo].[HistoryData]
			( [ProjectId]
			, [HistoryType]
			, [FieldName]
			, [SQLFieldTypeCode]
			, [BeforeValue]
			, [AfterValue]
			, [UserId]
			, [UserName]
			, [RecordId]
			, [ReasonForChange]
			, [DatetimeStamp]
			 ) 
		 VALUES 
			( @ProjectId
			, @HistoryType
			, @FieldName
			, @SQLFieldTypeCode
			, @BeforeValue
			, @AfterValue
			, @UserId
			, @UserName
			, @RecordId
			, @ReasonForChange
			, @DatetimeStamp
			 ) 
		 
		Set @id= Scope_Identity()
	End
 
 Select @id as id 
End' 
END
GO
/****** Object:  StoredProcedure [dbo].[spCustomStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCustomStepGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spCustomStepGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll Custom Steps from the OPUSSteps table 
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.TypeIndicator = 0 
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spConsensusReviewStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spConsensusReviewStepGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spConsensusReviewStepGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll ConsensusReview Steps from the OPUSSteps table 
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.TypeIndicator = 4 
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spCallForStandardStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCallForStandardStepGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spCallForStandardStepGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll CallForStandard Steps from the OPUSSteps table 
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.TypeIndicator = 3 
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spCallForNominationStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCallForNominationStepGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spCallForNominationStepGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll CallForNomination Steps from the OPUSSteps table 
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.TypeIndicator = 2 
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spCallForIntentStepGetAll]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spCallForIntentStepGetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spCallForIntentStepGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/10/2010 9:36:48 PM
-- Description: GetAll CallForIntent Steps from the OPUSSteps table 
-- =============================================
-- spOPUSStepsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[OPUSSteps] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.TypeIndicator = 1 
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spUserSet]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spUserSet] 
	 @Id bigint
	, @IMISUserId varchar(60) 
	, @IMISMemberType varchar(5) 
	, @UserName varchar(60) 
	, @Email varchar(100) 
	, @FirstName varchar(30) 
	, @LastName varchar(20) 
	, @Title varchar(80) 
	, @Active bit
	, @Deleted bit
	, @Locked bit
	, @CreatedBy varchar(60) 
	, @CreatedByDateTime varchar(60) 
	, @LastModifiedBy varchar(60) 
	, @LastModifiedByDateTime datetime
	, @DatetimeStamp datetime

As
Begin
-- =============================================
-- Author:		[Developer Name] (Pantheon Inc.)
-- Create date: 1/5/2010 11:47:43 PM
-- Description: Set Into Table Users
-- =============================================
-- spUsersSet ...........
		IF (@Id >0)
		Begin
			Update [dbo].[Users]
				 Set [IMISUserId]= @IMISUserId
				, [IMISMemberType]= @IMISMemberType
				, [UserName]= @UserName
				, [Email]= @Email
				, [FirstName]= @FirstName
				, [LastName]= @LastName
				, [Title]= @Title
				, [Active]= @Active
				, [Deleted]= @Deleted
				, [Locked]= @Locked
				, [CreatedBy]= @CreatedBy
				, [CreatedByDateTime]= @CreatedByDateTime
				, [LastModifiedBy]= @LastModifiedBy
				, [LastModifiedByDateTime]= @LastModifiedByDateTime
				, [DatetimeStamp]= @DatetimeStamp
				 
			 Where [Id]= @Id
	End
	Else
	Begin
		Insert Into [dbo].[Users]
			( [IMISUserId]
			, [IMISMemberType]
			, [UserName]
			, [Email]
			, [FirstName]
			, [LastName]
			, [Title]
			, [Active]
			, [Deleted]
			, [Locked]
			, [CreatedBy]
			, [CreatedByDateTime]
			, [LastModifiedBy]
			, [LastModifiedByDateTime]
			, [DatetimeStamp]
			 ) 
		 VALUES 
			( @IMISUserId
			, @IMISMemberType
			, @UserName
			, @Email
			, @FirstName
			, @LastName
			, @Title
			, @Active
			, @Deleted
			, @Locked
			, @CreatedBy
			, @CreatedByDateTime
			, @LastModifiedBy
			, @LastModifiedByDateTime
			, @DatetimeStamp
			 ) 
		 
		Set @Id= Scope_Identity()
	End
 
 Select @Id as Id 
End
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spUserRoleSet]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserRoleSet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spUserRoleSet] 
	 @UserId bigint, 
	 @RoleId bigint
As
Begin
-- =============================================
-- Author:		[Developer Name] (Pantheon Inc.)
-- Create date: 1/5/2010 11:56:59 PM
-- Description: Set Into Table UserRoles
-- =============================================
-- spUserRolesSet ...........
		Insert Into [dbo].[UserRoles]([UserId], [RoleId]) 
		VALUES (@UserId, @RoleId) 
End
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spUserActivitySet]    Script Date: 01/11/2010 00:19:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserActivitySet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spUserActivitySet] 
	 @Id bigint
	, @UserId bigint
	, @ActivityType int
	, @ActivityTime datetime
	, @IPAddress varchar(50) 
	, @RequestedURL varchar(400) 
	, @SessionId varchar(100) 
	, @RefUrl varchar(400) 
	, @Browser varchar(100) 
	, @ShortMessage varchar(2000) 
	, @LongMessage varchar(8000) 

As
Begin
-- =============================================
-- Author:		[Developer Name] (Pantheon Inc.)
-- Create date: 1/5/2010 11:54:58 PM
-- Description: Set Into Table UserActivities
-- =============================================
-- spUserActivitiesSet ...........
		IF (@Id >0)
		Begin
			Update [dbo].[UserActivities]
				 Set [UserId]= @UserId
				, [ActivityType]= @ActivityType
				, [ActivityTime]= @ActivityTime
				, [IPAddress]= @IPAddress
				, [RequestedURL]= @RequestedURL
				, [SessionId]= @SessionId
				, [RefUrl]= @RefUrl
				, [Browser]= @Browser
				, [ShortMessage]= @ShortMessage
				, [LongMessage]= @LongMessage
				 
			 Where [Id]= @Id
	End
	Else
	Begin
		Insert Into [dbo].[UserActivities]
			( [UserId]
			, [ActivityType]
			, [ActivityTime]
			, [IPAddress]
			, [RequestedURL]
			, [SessionId]
			, [RefUrl]
			, [Browser]
			, [ShortMessage]
			, [LongMessage]
			 ) 
		 VALUES 
			( @UserId
			, @ActivityType
			, @ActivityTime
			, @IPAddress
			, @RequestedURL
			, @SessionId
			, @RefUrl
			, @Browser
			, @ShortMessage
			, @LongMessage
			 ) 
		 
		Set @Id= Scope_Identity()
	End
 
 Select @Id as Id 
End ' 
END
GO
