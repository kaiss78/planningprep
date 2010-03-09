using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Domain.UserExams;
using App.Models.Exams;
using App.Core.Storage;

public partial class Pages_Exam : BasePage
{
    private int QuestionNo;
    private int ExamID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!LoadParams())
        {
            Response.Clear();
            Response.End();
        }
        IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(3);
        if (questions != null && questions.Count > 0)
        {
            QuestionForExamType question = GetCurrentQuestion(QuestionNo, questions);
            PopulateQuestion(question);
        }
    }

    private void PopulateQuestion(QuestionForExamType question)
    {
        lblQuestionTitle.Text = question.Question;

        rdoA.Text = question.AnswerA;
        rdoB.Text = question.AnswerB;
        rdoC.Text = question.AnswerC;
        rdoD.Text = question.AnswerD;

        string PrevUrl = string.Format("Exam.aspx?ExamID={0}&QuestionNo={1}", ExamID, QuestionNo - 1);
        string NextUrl = string.Format("Exam.aspx?ExamID={0}&QuestionNo={1}", ExamID, QuestionNo + 1);

        IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(3);
        
        hlinkNext.NavigateUrl = NextUrl;
        hlinkPrevious.NavigateUrl = PrevUrl;

        if (QuestionNo == questions.Count)
        {
            hlinkNext.Visible = false;
        }
        if (QuestionNo == 1)
        {
            hlinkPrevious.Visible = false;
        }

    }

    private QuestionForExamType GetCurrentQuestion(int QuestionNo, IList<QuestionForExamType> questions)
    {
        if (questions.Count >= QuestionNo)
        {
            return questions[QuestionNo - 1];
        }
        return null;
    }

    private bool LoadParams()
    {
        ExamID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.EXAM_ID);
        QuestionNo = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.QUESTION_NO);

        if (ExamID == 0 || QuestionNo == 0)
        {
            return false;
        }
        return true;
    }
    
}
