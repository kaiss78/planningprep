IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spHistoryDataSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spHistoryDataSet]
GO
CREATE PROCEDURE [dbo].[spHistoryDataSet] 
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
End 