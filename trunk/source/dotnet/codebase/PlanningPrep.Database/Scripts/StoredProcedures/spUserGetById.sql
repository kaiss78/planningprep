IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserGetById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserGetById]
GO
CREATE PROCEDURE [dbo].[spUserGetById] 
	@Id bigint
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 2/16/2010 5:56:25 PM
-- Description: GetById Into Table Users
-- =============================================
-- spUsersGetById ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[Users] tab (NOLOCK)
		WHERE tab.[Id]=@ID 
		  AND tab.[Deleted] = 0
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
GO 