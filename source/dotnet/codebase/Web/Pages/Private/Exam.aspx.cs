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
    private int IsNext;
    private string ExamKey;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            QuestionNo = 1;
            SetCurrentQuestionInfo();
            if (!LoadParams())
            {
                Response.Clear();
                Response.End();
            }

            IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(3);
            if (questions != null && questions.Count > 0)
            {
                QuestionForExamType question = GetQuestion(QuestionNo, questions);
                PopulateQuestion(question);
            }
        }
        else
        {
            LoadCurrentQuestionInfo();
        }
    }

    private void PopulateQuestion(QuestionForExamType question)
    {
        lblQuestionTitle.Text = question.Question;

        rdoA.Text = question.AnswerA;
        rdoB.Text = question.AnswerB;
        rdoC.Text = question.AnswerC;
        rdoD.Text = question.AnswerD;

        //string PrevUrl = string.Format("Exam.aspx?ExamID={0}&QuestionNo={1}&ExamKey={2}", ExamID, QuestionNo - 1,SessionCache.CurrentExamKey);
        //string NextUrl = string.Format("Exam.aspx?ExamID={0}&QuestionNo={1}&ExamKey={2}&IsNext={3}", ExamID, QuestionNo + 1, SessionCache.CurrentExamKey,1);

        IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(3);
        
        //hlinkNext.NavigateUrl = NextUrl;
        //hlinkPrevious.NavigateUrl = PrevUrl;

        lnkNext.Visible = true;
        lnkPrevious.Visible = true;

        if (QuestionNo == questions.Count)
        {
            lnkNext.Visible = false;
        }
        if (QuestionNo == 1)
        {
            lnkPrevious.Visible = false;
        }

    }

    private QuestionForExamType GetQuestion(int QuestionNo, IList<QuestionForExamType> questions)
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
        ExamKey = WebUtil.GetRequestParamValueInString(AppConstants.QueryString.EXAM_KEY);
        
        //if (ExamID == 0 || QuestionNo == 0 || string.IsNullOrEmpty(ExamKey))
        if (ExamID == 0 || QuestionNo == 0)
        {
            return false;
        }
        return true;
    }

    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(3);
        if (questions != null && questions.Count > 0)
        {
            QuestionNo--;
            SetCurrentQuestionInfo();
            QuestionForExamType question = GetQuestion(QuestionNo, questions);
            PopulateQuestion(question);
        }
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(3);
        if (questions != null && questions.Count > 0)
        {
            QuestionForExamType currentQuestion = GetQuestion(QuestionNo, questions);

            string selectedAnswer = GetSelectedAnswerChoice();
            if (selectedAnswer.Length > 0)
            {

            }

            QuestionNo++;
            SetCurrentQuestionInfo();
            QuestionForExamType nextQuestion = GetQuestion(QuestionNo, questions);
            PopulateQuestion(nextQuestion);
        }
    }

    private void SetCurrentQuestionInfo()
    {
        ViewState["CURRENT_QUESTION"] = QuestionNo;
    }

    private void LoadCurrentQuestionInfo()
    {
        QuestionNo = Convert.ToInt32(ViewState["CURRENT_QUESTION"]);
    }

    private string GetSelectedAnswerChoice()
    {
        if (rdoA.Checked)
        {
            return "A";
        }
        if (rdoB.Checked)
        {
            return "B";
        }
        if (rdoC.Checked)
        {
            return "C";
        }
        if (rdoD.Checked)
        {
            return "D";
        }

        return string.Empty;

    }
}
