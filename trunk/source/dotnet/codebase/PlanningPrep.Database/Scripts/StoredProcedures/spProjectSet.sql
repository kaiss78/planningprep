IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectSet]
GO
CREATE PROCEDURE [dbo].[spProjectSet] 
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

GO

/*
GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
*/

