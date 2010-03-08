




IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQuestionsDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spQuestionsDelete]
GO
CREATE PROCEDURE [dbo].[spQuestionsDelete] 
@Id int
AS
-- =============================================
-- Author:		Shubho (SmartAspects Inc.)
-- Create date: 3/8/2010 9:10:57 PM
-- Description: Delete Into Table tblQuestions
-- =============================================
-- sptblQuestionsDelete ...........
BEGIN

		DELETE FROM tblQuestions
		WHERE [QuestionID]=@Id

END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQuestionsGetById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spQuestionsGetById]
GO
CREATE PROCEDURE [dbo].[spQuestionsGetById] 
	@Id int
AS
-- =============================================
-- Author:		Shubho (SmartAspects Inc.)
-- Create date: 3/8/2010 9:10:57 PM
-- Description: GetById Into Table tblQuestions
-- =============================================
-- sptblQuestionsGetById ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[tblQuestions] tab WITH(NOLOCK)
		WHERE tab.[QuestionID]=@Id

		SET NOCOUNT OFF;
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQuestionsGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spQuestionsGetAll]
GO
CREATE PROCEDURE [dbo].[spQuestionsGetAll] 
AS
-- =============================================
-- Author:		Shubho (SmartAspects Inc.)
-- Create date: 3/8/2010 9:10:57 PM
-- Description: GetAll Into Table tblQuestions
-- =============================================
-- sptblQuestionsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[tblQuestions] tab  WITH(NOLOCK)
		ORDER BY tab.[QuestionID] DESC

		SET NOCOUNT OFF;
END
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQuestionsSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spQuestionsSet]
GO
CREATE PROCEDURE [dbo].[spQuestionsSet] 
	 @QuestionID int
	, @Question nvarchar (max)
	, @AnswerA nvarchar (max)
	, @AnswerB nvarchar (max)
	, @AnswerC nvarchar (max)
	, @AnswerD nvarchar (max)
	, @CorrectAnswer nvarchar(50) 
	, @Explanation nvarchar (max)
	, @WrittenBy nvarchar(50) 
	, @When datetime
	, @HistoryTheoryLaw bit
	, @TrendsIssues bit
	, @PlanMaking bit
	, @FunctionalTopics bit
	, @PlanImplementation bit
	, @Ethics bit
	, @ModifiedBy nvarchar(50) 
	, @ModifiedWhen datetime
	, @RandomOrder int
	, @Count int
	, @Rating float
	, @RateCount int
	, @RateTotal int

As
Begin
-- =============================================
-- Author:		Shubho (SmartAspects Inc.)
-- Create date: 3/8/2010 9:10:57 PM
-- Description: Set Into Table tblQuestions
-- =============================================
-- sptblQuestionsSet ...........
		IF (@QuestionID >0)
		Begin
			Update [dbo].[tblQuestions]
				 Set [Question]= @Question
				, [AnswerA]= @AnswerA
				, [AnswerB]= @AnswerB
				, [AnswerC]= @AnswerC
				, [AnswerD]= @AnswerD
				, [CorrectAnswer]= @CorrectAnswer
				, [Explanation]= @Explanation
				, [WrittenBy]= @WrittenBy
				, [When]= @When
				, [HistoryTheoryLaw]= @HistoryTheoryLaw
				, [TrendsIssues]= @TrendsIssues
				, [PlanMaking]= @PlanMaking
				, [FunctionalTopics]= @FunctionalTopics
				, [PlanImplementation]= @PlanImplementation
				, [Ethics]= @Ethics
				, [ModifiedBy]= @ModifiedBy
				, [ModifiedWhen]= @ModifiedWhen
				, [RandomOrder]= @RandomOrder
				, [Count]= @Count
				, [Rating]= @Rating
				, [RateCount]= @RateCount
				, [RateTotal]= @RateTotal
				 
			 Where [QuestionID]= @QuestionID
	End
	Else
	Begin
		Insert Into [dbo].[tblQuestions]
			( [Question]
			, [AnswerA]
			, [AnswerB]
			, [AnswerC]
			, [AnswerD]
			, [CorrectAnswer]
			, [Explanation]
			, [WrittenBy]
			, [When]
			, [HistoryTheoryLaw]
			, [TrendsIssues]
			, [PlanMaking]
			, [FunctionalTopics]
			, [PlanImplementation]
			, [Ethics]
			, [ModifiedBy]
			, [ModifiedWhen]
			, [RandomOrder]
			, [Count]
			, [Rating]
			, [RateCount]
			, [RateTotal]
			 ) 
		 VALUES 
			( @Question
			, @AnswerA
			, @AnswerB
			, @AnswerC
			, @AnswerD
			, @CorrectAnswer
			, @Explanation
			, @WrittenBy
			, @When
			, @HistoryTheoryLaw
			, @TrendsIssues
			, @PlanMaking
			, @FunctionalTopics
			, @PlanImplementation
			, @Ethics
			, @ModifiedBy
			, @ModifiedWhen
			, @RandomOrder
			, @Count
			, @Rating
			, @RateCount
			, @RateTotal
			 ) 
		 
		Set @QuestionID= Scope_Identity()
	End
 
 Select @QuestionID as QuestionID 
End
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spQuestionsGetForUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spQuestionsGetForUser]
GO
CREATE PROCEDURE [dbo].[spQuestionsGetForUser] 
AS
-- =============================================
-- Author:		Shubho (SmartAspects Inc.)
-- Create date: 3/8/2010 9:10:57 PM
-- Description: GetForUser Into Table tblQuestions
-- =============================================
-- sptblQuestionsGetForUser ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[tblQuestions] tab  WITH(NOLOCK)
	ORDER BY tab.[QuestionID] DESC

	SET NOCOUNT OFF;
END
GO

