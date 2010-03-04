IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRoleGetAllForUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRoleGetAllForUser]
GO
CREATE PROCEDURE [dbo].[spRoleGetAllForUser] 
	   @UserId bigint
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 2/21/2010 5:03:00 PM
-- Description: GetForUser Into Table UserRoles
-- =============================================
-- i.e. test example
-- exec spRoleGetAllForUser 1
BEGIN
		SET NOCOUNT ON;

		SELECT	r.*
		FROM    UserRoles ur WITH(NOLOCK)
				INNER JOIN Roles r WITH(NOLOCK) ON r.Id = ur.RoleId 
				INNER JOIN Users u WITH(NOLOCK) ON u.Id = ur.UserId
		WHERE   ur.[UserId]= @UserId
		  AND   r.Active = 1 and r.Deleted = 0
		ORDER BY r.[Id] DESC, isnull(r.[LastModifiedByDateTime],r.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
GO