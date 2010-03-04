 IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectGetById]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectGetById]
GO
CREATE PROCEDURE [dbo].[spProjectGetById] 
	@Id bigint
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/6/2010 12:53:28 AM
-- Description: GetById Into Table Projects
-- =============================================
-- spProjectsGetById ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[Projects] tab (NOLOCK)
		WHERE tab.[Id]=@ID 
		  AND tab.[Deleted] = 0
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
GO