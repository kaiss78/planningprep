IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserRoleSet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserRoleSet]
GO
CREATE PROCEDURE [dbo].[spUserRoleSet] 
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