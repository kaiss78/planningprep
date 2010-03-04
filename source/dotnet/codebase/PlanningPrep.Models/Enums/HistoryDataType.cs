using System;

namespace PlanningPrep.Models.Enums
{
    [Flags]
    public enum HistoryType : byte
    {
        Project = 1,
        Committee = 2,
        Staffing = 3,
        Intent = 4,
        IntentSubmission = 5,
        ProjectStep = 6,
        CallForNomination = 7,
        NominationCommittee = 8,
        NominationPeriod = 9,
        NominationCommentingPeriod = 10,
        Nominee = 11,
        CallForStandard = 12,
        MeasureSubmissionPeriod = 13,
        ReassignedSubmitter = 14,
        MeasureStatus = 15,
        CandidateConsensusStandardsReviewData = 16,
    }
}


