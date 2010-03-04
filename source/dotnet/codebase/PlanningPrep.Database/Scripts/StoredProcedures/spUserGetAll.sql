IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserGetAll]
GO
CREATE PROCEDURE [dbo].[spUserGetAll] 
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 2/17/2010 12:51:29 PM
-- Description: GetAll Into Table Users
-- =============================================
-- spUsersGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[Users] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.[Active] = 1
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
GO 