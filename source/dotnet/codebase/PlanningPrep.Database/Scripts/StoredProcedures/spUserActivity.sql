IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserUserActivitySet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserActivitySet]
GO
CREATE PROCEDURE [dbo].[spUserActivitySet] 
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
End 