IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRoleSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRoleSet]
GO
CREATE PROCEDURE [dbo].[spRoleSet] 
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
End 