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
    protected int ExamSessionID;
    protected int Seconds;
    protected int Minutes;
    private string ExamKey;
    private string Action;
    private string ACTION_NEW_EXAM = "New";
    private string ACTION_CONTINUE_EXAM = "Continue";
    private string ACTION_EXAM_FINISHED = "Finished";
    UserExam currentUserExam = null;
    bool DeleteExistingExamInfoOnContinue = true;

    UserExamManager userExamManager = new UserExamManager();
    

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!LoadParams())
        {
            Response.Clear();
            Response.End();
            return;
        }

        if (IsTimerElapsed())
        {
            SaveAnswer(null,true);
            Response.Redirect("ExamResult.aspx?ExamSessionID=" + ExamSessionID);
            return;
        }


        if (!IsPostBack)
        {
            ClearCheckBoxes();
            SessionCache.SetExamStartTimeInfo();
            QuestionNo = 1;
            SetCurrentQuestionInfo();
            if (Action == ACTION_NEW_EXAM)
            {
                currentUserExam = CreateNewExamSessionForUser();
                SetCurrentExamSessionInfo((int)currentUserExam.Id);
            }
            else
            {
                if (DeleteExistingExamInfoOnContinue)
                {
                    DeleteExistingExamInfo();
                }
                SetCurrentExamSessionInfo(ExamSessionID);
            }
            PopulateQuestion();
        }
        else
        {
            LoadCurrentQuestionInfo();
            LoadCurrentExamSessionInfo();
            SetDateTimeInfoForCurrentQuestion();
        }

        SetTimerInfo();
        
    }

   
    private void SaveAnswer(ExamSaved questionToSave,bool finalQuestion)
    {
        DateTime examStartTime = SessionCache.GetExamStartTimeInfo();
        currentUserExam.TotalTime += DateTime.Now.Subtract(examStartTime).Seconds;
        if (finalQuestion)
        {
            currentUserExam.EndDate = DateTime.Now;
        }
        userExamManager.SaveOrUpdateSavedQuestion(questionToSave, currentUserExam);
    }

    private void SetTimerInfo()
    {
        int totalAllowedSeconds = ConfigReader.ExamLengthInMinutes * 60;
        if (IsPostBack)
        {
            DateTime examStartTime = SessionCache.GetExamStartTimeInfo();
            int elapsedSeconds = DateTime.Now.Subtract(examStartTime).Minutes * 60 + DateTime.Now.Subtract(examStartTime).Seconds;
            totalAllowedSeconds -= elapsedSeconds;
        }
        Minutes = totalAllowedSeconds / 60;
        Seconds = totalAllowedSeconds % 60;
    }

    private bool IsTimerElapsed()
    {
        int totalAllowedSeconds = ConfigReader.ExamLengthInMinutes * 60;
        if (IsPostBack || Action == ACTION_EXAM_FINISHED)
        {
            DateTime examStartTime = SessionCache.GetExamStartTimeInfo();
            int elapsedSeconds = DateTime.Now.Subtract(examStartTime).Minutes * 60 + DateTime.Now.Subtract(examStartTime).Seconds;
            totalAllowedSeconds -= elapsedSeconds;
        }

        return totalAllowedSeconds <= 0 ? true : false;
    }

    private void DeleteExistingExamInfo()
    {
        userExamManager.Delete(ExamSessionID);
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
            if (question == null) return;

            SetDateTimeInfoForCurrentQuestion();

            lblQuestionTitle.Text = question.Question;
            Page.Title = AppUtil.GetPageTitle(question.Question);

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
                currentUserExam = userExamManager.Get(ExamSessionID);
                ExamID = currentUserExam.ExamID;
            }
        }
        else if (Action == ACTION_NEW_EXAM)
        {
            if (ExamID == 0)
            {
                return false;
            }
        }
        else if(Action == ACTION_EXAM_FINISHED)
        {
            currentUserExam = userExamManager.Get(ExamSessionID);
            ExamID = currentUserExam.ExamID;
            return true;
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
            DateTime startTime = GetDateTimeInfoForCurrentQuestion();
            questionToSave.Time = DateTime.Now.Subtract(startTime).Seconds;
            questionToSave.TimeStamp = DateTime.Now;
            questionToSave.UserID = SessionCache.CurrentUser.Author_ID;

            bool finalQuestion = QuestionNo == questions.Count?true:false;
            SaveAnswer(questionToSave,finalQuestion);
        }
    }

    protected void lnkNext_Click(object sender, EventArgs e)
    {
        
        IList<QuestionForExamType> questions = SessionCache.Instance.GetExamQuestionsForExamType(ExamID);
        
        if (questions != null && questions.Count > 0)
        {
            SaveCurrentQuestionInfo(questions);
            if (QuestionNo == questions.Count)
            {
                Response.Redirect("ExamResult.aspx");
            }
            else
            {
                QuestionNo++;
                SetCurrentQuestionInfo();
                PopulateQuestion();
            }
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

    private void SetDateTimeInfoForCurrentQuestion()
    {
        Session["CURRENT_QUESTION_START_TIME"] = DateTime.Now;
    }

    private DateTime GetDateTimeInfoForCurrentQuestion()
    {
        return Convert.ToDateTime(Session["CURRENT_QUESTION_START_TIME"]);
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
