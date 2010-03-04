IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserActivityGetByUserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserActivityGetByUserId]
GO
CREATE PROCEDURE [dbo].[spUserActivityGetByUserId] 
	   @UserId bigint
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 2/18/2010 9:11:33 AM
-- Description: GetByUserId Into Table UserActivities
-- =============================================
-- spUserActivitiesGetByUserId ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[UserActivities] tab (NOLOCK)
		WHERE tab.[UserId]= @UserId
		  AND tab.[Deleted] = 0 AND tab.[Active] = 1
		ORDER BY tab.[Id] DESC

		SET NOCOUNT OFF;
END
GO 