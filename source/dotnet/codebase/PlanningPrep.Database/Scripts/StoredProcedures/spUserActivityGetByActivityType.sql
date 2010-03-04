IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserActivityGetByActivityType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserActivityGetByActivityType]
GO
CREATE PROCEDURE [dbo].[spUserActivityGetByActivityType] 
	   @ActivityType int
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 2/18/2010 10:18:26 AM
-- Description: GetByActivityType Into Table UserActivities
-- =============================================
-- spUserActivitiesGetByActivityType ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[UserActivities] tab (NOLOCK)
		WHERE  tab.[ActivityType]= @ActivityType
		  AND tab.[Deleted] = 0 AND tab.[Active] = 1
		ORDER BY tab.[Id] DESC, ActivityType ASC

		SET NOCOUNT OFF;
END
GO 