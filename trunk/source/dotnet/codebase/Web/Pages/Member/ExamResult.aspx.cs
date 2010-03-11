using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Domain.UserExams;
using App.Models.UserExams;
using App.Models.Exams;
using System.Drawing;

public partial class Pages_Private_ExamResult : System.Web.UI.Page
{
    int ExamSessionID;
    string Action;
    string ACTION_FINISH_RESULT = "Finish";
    UserExamManager userExamManager = new UserExamManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        ExamSessionID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.EXAM_SESSION_ID);
        Action = WebUtil.GetRequestParamValueInString(AppConstants.QueryString.EXAM_ACTION);
        if (ExamSessionID == 0)
        {
            return;
        }
        UserExam currentUserExam = userExamManager.Get(ExamSessionID);
        lblExamNo.Text = currentUserExam.ExamID.ToString();
        lblExamNo2.Text = lblExamNo.Text;
        Page.Title = AppUtil.GetPageTitle("Exam Result for Exam #" + currentUserExam.ExamID);

        ExamTotal examTotal = FinishExam(currentUserExam);
        PopulateResultSummary(examTotal,currentUserExam);
        PopulateResultDetails();
    }

    private void PopulateResultDetails()
    {
        IList<ResultDetails> ResultDetails = userExamManager.GetResultDetailsByExamSessionID(ExamSessionID);
        gvResultDetails.DataSource = ResultDetails;
        gvResultDetails.DataBind();
    }

    private ExamTotal FinishExam(UserExam currentUserExam)
    {
        DateTime examStartTime = SessionCache.GetExamStartTimeInfo();
        
        ExamTotal examTotal = null;
        if (currentUserExam.EndDate != DateTime.MinValue || ACTION_FINISH_RESULT == Action)
        {
            currentUserExam.TotalTime = DateTime.Now.Subtract(examStartTime).Seconds;
            currentUserExam.EndDate = DateTime.Now;

            userExamManager.SaveOrUpdateSavedQuestion(null, currentUserExam);

            examTotal = userExamManager.ProcessResult(ExamSessionID);

            SessionCache.ClearExamSessionInfo();
        }
        else
        {
            examTotal = userExamManager.GetExamTotal(ExamSessionID);
        }

        return examTotal;
    }
    
    private void PopulateResultSummary(ExamTotal examTotal, UserExam currentUserExam)
    {
        if (examTotal != null)
        {
            int totalQuestions = examTotal.CountOfQuestionID;
            int totalCorrect = examTotal.SumOfCorrect;
            float percentCorrect = (float)totalCorrect / (float)totalQuestions * 100;
            int avgTime = currentUserExam.TotalTime / totalQuestions;

            lblTotalQuestions.Text = totalQuestions.ToString();
            lblTotalCorrectAnswers.Text = totalCorrect.ToString();
            lblPercentCorrectAnswers.Text = string.Format("{0}%", percentCorrect.ToString());
            lblAvgTimePerQuestion.Text = avgTime.ToString();
        }
    }



    protected void gvResultDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label label = (Label)e.Row.FindControl("lblResult");
        if (label != null)
        {
            if (label.Text == "CORRECT")
            {
                label.ForeColor = Color.Green;
            }
            else
            {
                label.ForeColor = Color.Red;
            }
        }
    }
}
