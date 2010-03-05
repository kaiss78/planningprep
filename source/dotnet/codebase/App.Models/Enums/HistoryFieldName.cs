using System;
using System.ComponentModel;

namespace App.Models.Enums
{
    [Flags]
    public enum HistoryFieldName
    {
        [Description("Start Date")]
        StartDate,
        [Description("End Date")]
        EndDate,
        [Description("Active")]
        Active,
        [Description("Project Role")]
        ProjectRole,
        [Description("Web Title")]
        WebTitle,
        [Description("Status")]
        CommitteeStatus,
        [Description("Short biography of nominee")]
        NomineeShortBiography,
        [Description("Before Period Description")]
        BeforePeriodDescription,
        [Description("During Period Description")]
        DuringPeriodDescription,
        [Description("After Period Description")]
        AfterPeriodDescription,
        [Description("Background")]
        Background,
        [Description("Scope of Activities")]
        ScopeOfActivities,
        [Description("NQF Process")]
        NqfProcess, 
        [Description("Title")]
        SubmissionTitle,
        [Description("Description")]
        SubmissionDescription,
        [Description("Instructions")]
        Instructions,
        [Description("Remarks")]
        Remarks,
        [Description("Reassigned Submitter")]
        ReassignedSubmitter,
        [Description("Measure Status")]
        Status
    }
}


