IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserSet]
GO
CREATE PROCEDURE [dbo].[spUserSet] 
	 @Id bigint
	, @IMISUserId varchar(60) 
	, @IMISMemberType varchar(5) 
	, @UserName varchar(60) 
	, @Email varchar(100) 
	, @FirstName varchar(30) 
	, @LastName varchar(20) 
	, @Title varchar(80) 
	, @Organization varchar(100) 
	, @WorkPhone varchar(50) 
	, @HomePhone varchar(50) 
	, @City varchar(75) 
	, @State varchar(50) 
	, @PrimaryCouncil varchar(50) 
	, @ContactId varchar(50) 
	, @RoleId bigint
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
-- Create date: 2/16/2010 11:49:02 PM
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
				, [Organization]= @Organization
				, [WorkPhone]= @WorkPhone
				, [HomePhone]= @HomePhone
				, [City]= @City
				, [State]= @State
				, [PrimaryCouncil]= @PrimaryCouncil
				, [ContactId]= @ContactId
				, [RoleId]= @RoleId
				, [Active]= @Active
				, [Deleted]= @Deleted
				, [Locked]= @Locked
				, [CreatedBy]= @CreatedBy
				, [CreatedByDateTime]= @CreatedByDateTime
				, [LastModifiedBy]= @LastModifiedBy
				, [LastModifiedByDateTime]= @LastModifiedByDateTime
				, [DatetimeStamp]= @DatetimeStamp
				 
			 Where [Id]= @Id
			 
			 Select Scope_Identity();
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
			, [Organization]
			, [WorkPhone]
			, [HomePhone]
			, [City]
			, [State]
			, [PrimaryCouncil]
			, [ContactId]
			, [RoleId]
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
			, @Organization
			, @WorkPhone
			, @HomePhone
			, @City
			, @State
			, @PrimaryCouncil
			, @ContactId
			, @RoleId
			, @Active
			, @Deleted
			, @Locked
			, @CreatedBy
			, @CreatedByDateTime
			, @LastModifiedBy
			, @LastModifiedByDateTime
			, @DatetimeStamp
			 ) 
		 
		Select Scope_Identity();
	End
End