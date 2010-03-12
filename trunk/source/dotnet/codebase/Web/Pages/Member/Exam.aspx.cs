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
    protected double Progress;
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
        //SessionCache.ClearExamSessionInfo();
        if (!LoadParams())
        {
            //If required parameters are not supplied, redirect to Error page
            Response.Redirect("~/Error.aspx?ErrorCode=3");
            return;
        }

        if (IsTimerElapsed())
        {
            //If time is over, save current answer and redirect to the result page
            SaveAnswer(null,true);
            Response.Redirect("ExamResult.aspx?Action=Finish&ExamSessionID=" + ExamSessionID);
            return;
        }


        if (!IsPostBack)
        {
            //This is the first hit in the exam page

            string examKey = WebUtil.GetExamKeyForExamType(ExamID);
            if (SessionCache.ExamOngoing)
            {
                //If an active exam is already ongoing
                if (examKey != SessionCache.CurrentExamKey)
                {
                    //If the ongoing exam's key does not match with the current exam key,
                    //Redirect user to the error page
                    Response.Redirect("~/Error.aspx?ErrorCode=2");
                    return;
                }
            }

            ClearCheckBoxes();
            
            if (Action == ACTION_NEW_EXAM)
            {
                //If this is a new exam request, create a new Exam session
                currentUserExam = CreateNewExamSessionForUser();
                //Set the current examSessionID into the view state
                SessionCache.SetCurrentExamSessionID((int)currentUserExam.Id);
                //And redirect to continue mode
                Response.Redirect(string.Format("Exam.aspx?Action=Continue&ExamSessionID={0}", currentUserExam.Id));
                return;
            }
            else
            {
                //Start the exam if no exam is ongoing at this moment
                if (!SessionCache.ExamOngoing)
                {
                    //The exam has just started. So, set the exam key in the session
                    SessionCache.CurrentExamKey = examKey;
                    //Also, put the exam started flag in the session
                    SessionCache.ExamOngoing = true;

                    //An exam will always start with question no 1
                    QuestionNo = 1;
                    SessionCache.AnsweredQuestionCount = 0;
                    //Set current question no in the ViewState
                    SessionCache.SetCurrentQuestionID(QuestionNo);

                    //Set exam start time in the Session
                    SessionCache.SetExamStartTime();
                    

                    if (DeleteExistingExamInfoOnContinue)
                    {
                        //If Deletion of existing exam result for the Session is enabled,
                        //Delete existing info and clear the Exam session information
                        currentUserExam.TotalTime = 0;
                        userExamManager.SaveOrUpdate(currentUserExam);
                        DeleteExistingExamInfo();
                    }
                    //Set current exam session id into the viewstate
                    SessionCache.SetCurrentExamSessionID(ExamSessionID);
                }
                else 
                {
                    QuestionNo = SessionCache.GetCurrentQuestionID();
                    ExamSessionID = SessionCache.GetCurrentExamSessionID();
                }
            }
            PopulateQuestion();
            
        }
        else
        {
            QuestionNo = SessionCache.GetCurrentQuestionID();
            ExamSessionID = SessionCache.GetCurrentExamSessionID();
            SessionCache.SetDateTimeInfoForCurrentQuestion();
        }

        StartCountDown();
        
    }

   
    private void SaveAnswer(ExamSaved questionToSave,bool finalQuestion)
    {
        DateTime examStartTime = SessionCache.GetExamStartTime();
        currentUserExam.TotalTime = DateTime.Now.Subtract(examStartTime).Seconds;
        if (finalQuestion)
        {
            currentUserExam.EndDate = DateTime.Now;
        }
        userExamManager.SaveOrUpdateSavedQuestion(questionToSave, currentUserExam);
    }

    private void StartCountDown()
    {
        int totalAllowedSeconds = ConfigReader.ExamLengthInMinutes * 60;
        if (IsPostBack || SessionCache.ExamOngoing)
        {
            DateTime examStartTime = SessionCache.GetExamStartTime();
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
            DateTime examStartTime = SessionCache.GetExamStartTime();
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

            SessionCache.SetDateTimeInfoForCurrentQuestion();

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

        int clear = WebUtil.GetRequestParamValueInInt("Clear");
        if(clear == 1)
        {
            SessionCache.ClearExamSessionInfo();
        }

        if (Action == ACTION_CONTINUE_EXAM)
        {
            if (ExamSessionID == 0) return false;
            if (ExamID == 0)
            {
                currentUserExam = userExamManager.Get(ExamSessionID);
                if (currentUserExam.UserID != SessionCache.CurrentUser.Author_ID)
                {
                    Response.Redirect("~/Error.aspx?ErrorCode=1");
                    
                    return false;
                }
                if (currentUserExam.EndDate != DateTime.MinValue)
                {
                    Response.Redirect("ExamResult.aspx?ExamSessionID=" + ExamSessionID);
                }
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
            SessionCache.SetCurrentQuestionID(QuestionNo);
            PopulateQuestion();
        }
        Progress = Math.Round((float)SessionCache.AnsweredQuestionCount / (float)20 * 10, 3);
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
            
                questionToSave.Answer = selectedAnswer;
                questionToSave.ExamSessionID = ExamSessionID;
                questionToSave.QuestionID = currentQuestion.QuestionID;
                DateTime startTime = SessionCache.GetDateTimeInfoForCurrentQuestion();
                questionToSave.Time = DateTime.Now.Subtract(startTime).Seconds;
                questionToSave.TimeStamp = DateTime.Now;
                questionToSave.UserID = SessionCache.CurrentUser.Author_ID;

                SessionCache.AnsweredQuestionCount++;
            }

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
                SessionCache.SetCurrentQuestionID(QuestionNo);
                PopulateQuestion();
            }
        }

        Progress = Math.Round((float)SessionCache.AnsweredQuestionCount / (float)20 * 10, 3);
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
