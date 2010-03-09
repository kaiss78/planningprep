using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Domain.UserExams;
using App.Models.Exams;
using App.Core.Storage;
using App.Models.UserExams;
using App.Domain.Exams;

public partial class Pages_Exam : BasePage
{
    private int QuestionNo;
    private int ExamID;
    private int ExamSessionID;
    private int IsNext;
    private string ExamKey;
    private string Action;
    private string ACTION_NEW_EXAM = "New";
    private string ACTION_CONTINUE_EXAM = "Continue";

    UserExamManager userExamManager = new UserExamManager();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!LoadParams())
        {
            Response.Clear();
            Response.End();
            return;
        }

        

        if (!IsPostBack)
        {
            ClearCheckBoxes();

            QuestionNo = 1;
            SetCurrentQuestionInfo();
            if (Action == ACTION_NEW_EXAM)
            {
                UserExam userExam = CreateNewExamSessionForUser();
                SetCurrentExamSessionInfo((int)userExam.Id);
            }
            else
            {
                SetCurrentExamSessionInfo(ExamSessionID);
            }
            PopulateQuestion();
        }
        else
        {
            LoadCurrentQuestionInfo();
            LoadCurrentExamSessionInfo();
        }
    }

    private void ClearCheckBoxes()
    {
        rdoA.Checked = false;
        rdoB.Checked = false;
        rdoC.Checked = false;
        rdoD.Checked = false;
    }

    private UserExam CreateNewExamSessionForUser()
    {
        UserExam userExam = new UserExam();
        userExam.StartDate = DateTime.Now;
        userExam.UserID = SessionCache.CurrentUser.Author_ID;
        userExam.ExamID = ExamID;

        userExamManager.SaveOrUpdate(userExam);

        return userExam;
    }

    private void PopulateQuestion()
    {

        IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(ExamID);

        if (questions != null && questions.Count > 0)
        {
            QuestionForExamType question = GetQuestion(QuestionNo, questions);
            lblQuestionTitle.Text = question.Question;

            rdoA.Text = question.AnswerA;
            rdoB.Text = question.AnswerB;
            rdoC.Text = question.AnswerC;
            rdoD.Text = question.AnswerD;

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

            ExamSaved questionToSave = userExamManager.GetSavedExamByExamSessionIDAndQuestionID(ExamSessionID, question.QuestionID);
            rdoA.Checked = false;
            rdoB.Checked = false;
            rdoC.Checked = false;
            rdoD.Checked = false;
            if (questionToSave != null)
            {
                if (questionToSave.Answer == "A")
                {
                    rdoA.Checked = true;
                }
                else if (questionToSave.Answer == "B")
                {
                    rdoB.Checked = true;
                }
                else if (questionToSave.Answer == "C")
                {
                    rdoC.Checked = true;
                }
                else
                {
                    rdoD.Checked = true;
                }
            }
            else
            {
                ClearCheckBoxes();
            }
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
        ExamSessionID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.EXAM_SESSION_ID);
        ExamKey = WebUtil.GetRequestParamValueInString(AppConstants.QueryString.EXAM_KEY);
        Action = WebUtil.GetRequestParamValueInString(AppConstants.QueryString.EXAM_ACTION);
        
        if (Action == ACTION_CONTINUE_EXAM)
        {
            if (ExamSessionID == 0) return false;
            if (ExamID == 0)
            {
                UserExam userExam = userExamManager.Get(ExamSessionID);
                ExamID = userExam.ExamID;
            }
        }
        else if (Action == ACTION_NEW_EXAM)
        {
            if (ExamID == 0)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        return true;
    }

    protected void lnkPrevious_Click(object sender, EventArgs e)
    {
        IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(ExamID);
        if (questions != null && questions.Count > 0)
        {
            //SaveCurrentQuestionInfo(questions);
            QuestionNo--;
            SetCurrentQuestionInfo();
            PopulateQuestion();
        }
    }

    private void SaveCurrentQuestionInfo(IList<QuestionForExamType> questions)
    {
        QuestionForExamType currentQuestion = GetQuestion(QuestionNo, questions);

        string selectedAnswer = GetSelectedAnswerChoice();
        if (selectedAnswer.Length > 0)
        {

            ExamSaved questionToSave = userExamManager.GetSavedExamByExamSessionIDAndQuestionID(ExamSessionID, currentQuestion.QuestionID);

            if (questionToSave == null || questionToSave.Id == 0)
            {
                questionToSave = new ExamSaved();
            }
            questionToSave.Answer = selectedAnswer;
            questionToSave.ExamSessionID = ExamSessionID;
            questionToSave.QuestionID = currentQuestion.QuestionID;
            questionToSave.Time = 100;
            questionToSave.TimeStamp = DateTime.Now;
            questionToSave.UserID = SessionCache.CurrentUser.Author_ID;

            userExamManager.SaveOrUpdateSavedQuestion(questionToSave);

        }
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(ExamID);
        if (questions != null && questions.Count > 0)
        {
            SaveCurrentQuestionInfo(questions);
            QuestionNo++;
            SetCurrentQuestionInfo();
            PopulateQuestion();
        }
    }

    private void SetCurrentExamSessionInfo(int examSessionID)
    {
        ExamSessionID = examSessionID;
        ViewState["CURRENT_EXAM_SESSION_ID"] = ExamSessionID;
    }

    private void LoadCurrentExamSessionInfo()
    {
        ExamSessionID = Convert.ToInt32(ViewState["CURRENT_EXAM_SESSION_ID"]);
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
