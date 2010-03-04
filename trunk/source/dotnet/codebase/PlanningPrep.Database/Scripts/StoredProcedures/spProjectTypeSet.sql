IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectTypeSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectTypeSet]
GO
CREATE PROCEDURE [dbo].[spProjectTypeSet] 
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
 