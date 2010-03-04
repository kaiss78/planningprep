IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_ProjectSubmission]'))
DROP VIEW [dbo].[vw_ProjectSubmission]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_ProjectSubmission]
AS
	SELECT DISTINCT 
                      psub.Id, psub.Name, psub.ProjectId, psub.Active, psub.Deleted, psub.Locked, psub.CreatedBy, psub.CreatedByDateTime, psub.LastModifiedBy, 
                      psub.LastModifiedByDateTime, psub.DatetimeStamp, pstep.Id AS Expr1, pstep.SubmissionId, pstep.StepId, pstep.ParentStepId, pstep.DefinitionId, pstep.DataId, 
                      pstep.SortOrder, pstep.Active AS Expr2, pstep.Deleted AS Expr3, pstep.Locked AS Expr4, pstep.CreatedBy AS Expr5, pstep.CreatedByDateTime AS Expr6, 
                      pstep.LastModifiedBy AS Expr7, pstep.LastModifiedByDateTime AS Expr8, pstep.DatetimeStamp AS Expr9, ostep.Id AS Expr10, ostep.TypeId, ostep.TypeIndicator, 
                      ostep.Name AS Expr11, ostep.StartDate, ostep.EndDate, ostep.BeforePeriodDescription, ostep.DuringPeriodDescription, ostep.AfterPeriodDescription, 
                      ostep.DetailPage, ostep.Active AS Expr12, ostep.Deleted AS Expr13, ostep.Locked AS Expr14, ostep.CreatedBy AS Expr15, ostep.CreatedByDateTime AS Expr16, 
                      ostep.LastModifiedBy AS Expr17, ostep.LastModifiedByDateTime AS Expr18, ostep.DatetimeStamp AS Expr19, ostep2.Id AS Expr20, ostep2.TypeId AS Expr21, 
                      ostep2.TypeIndicator AS Expr22, ostep2.Name AS Expr23, ostep2.StartDate AS Expr24, ostep2.EndDate AS Expr25, ostep2.BeforePeriodDescription AS Expr26, 
                      ostep2.DuringPeriodDescription AS Expr27, ostep2.AfterPeriodDescription AS Expr28, ostep2.DetailPage AS Expr29, ostep2.Active AS Expr30, 
                      ostep2.Deleted AS Expr31, ostep2.Locked AS Expr32, ostep2.CreatedBy AS Expr33, ostep2.CreatedByDateTime AS Expr34, ostep2.LastModifiedBy AS Expr35, 
                      ostep2.LastModifiedByDateTime AS Expr36, ostep2.DatetimeStamp AS Expr37, psd.Id AS Expr38, psd.DefinitionId AS Expr39, psd.ProjectStepId, psd.Value, 
                      psd.Active AS Expr40, psd.Deleted AS Expr41, psd.Locked AS Expr42, psd.CreatedBy AS Expr43, psd.CreatedByDateTime AS Expr44, psd.LastModifiedBy AS Expr45, 
                      psd.LastModifiedByDateTime AS Expr46, psd.DatetimeStamp AS Expr47
	FROM         dbo.ProjectSubmissions AS psub LEFT OUTER JOIN
                      dbo.ProjectSteps AS pstep INNER JOIN
                      dbo.OPUSSteps AS ostep ON ostep.Id = pstep.StepId LEFT OUTER JOIN
                      dbo.OPUSSteps AS ostep2 ON ostep2.Id = pstep.ParentStepId LEFT OUTER JOIN
                      dbo.ProjectStepData AS psd ON psd.Id = pstep.DataId ON pstep.SubmissionId = psub.Id

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2[66] 3) )"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2) )"
      End
      ActivePaneConfig = 5
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ostep"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "psd"
            Begin Extent = 
               Top = 6
               Left = 282
               Bottom = 125
               Right = 488
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "pstep"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "psub"
            Begin Extent = 
               Top = 126
               Left = 282
               Bottom = 245
               Right = 488
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ostep2"
            Begin Extent = 
               Top = 6
               Left = 526
               Bottom = 125
               Right = 732
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ProjectSubmission'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ProjectSubmission'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_ProjectSubmission'
GO


