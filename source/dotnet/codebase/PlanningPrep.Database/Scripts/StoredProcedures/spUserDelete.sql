IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUserDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUserDelete]
GO
CREATE PROCEDURE [dbo].[spUserDelete] 
	@Id bigint
AS
-- =============================================
-- Author:		Jason Duffus (Pantheon Inc.)
-- Create date: 2/17/2010 12:49:25 PM
-- Description: Delete Into Table Users
-- =============================================
-- spUsersDelete ...........
BEGIN

		DELETE FROM Users
		WHERE [Id]=@ID 
		  AND [Locked] = 0

END
GO 