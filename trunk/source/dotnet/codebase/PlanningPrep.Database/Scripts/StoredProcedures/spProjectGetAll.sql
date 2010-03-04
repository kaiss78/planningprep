IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spProjectGetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spProjectGetAll]
GO
CREATE PROCEDURE [dbo].[spProjectGetAll] 
	@Id bigint
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 1/9/2010 7:34:55 PM
-- Description: GetAll from Projects table
-- =============================================
-- spProjectsGetAll ...........
BEGIN
		SET NOCOUNT ON;

		SELECT tab.*  
		FROM [dbo].[Projects] tab (NOLOCK)
		WHERE tab.[Deleted] = 0 AND tab.[Active] = 1
		ORDER BY tab.[Id] DESC, isnull(tab.[LastModifiedByDateTime],tab.[CreatedByDateTime]) DESC

		SET NOCOUNT OFF;
END
GO 