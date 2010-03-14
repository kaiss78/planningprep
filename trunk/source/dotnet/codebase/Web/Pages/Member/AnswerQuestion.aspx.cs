using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using App.Domain.Questions;
using App.Models.Questions;
using App.Models.Answers;
using App.Models.AnswerTotals;
using App.Domain.AnswerTotals;
using App.Domain.Answer;

public partial class Pages_Member_AnswerQuestion : BasePage
{
    int QuestionID;
    QuestionsManager questionManager = new QuestionsManager();
    AnswerTotalManager answerTotalManager = new AnswerTotalManager();
    AnswersManager answerManager = new AnswersManager();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!LoadParams())
        {
            Response.Redirect("~/Error.aspx?ErrorCode=3");
            return;
        }
        if (!IsPostBack)
        {
            PopulateQuestion();
        }
    }

    private bool LoadParams()
    {
        QuestionID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.QUESTION_ID);
        if (QuestionID == 0)
        {
            return false;
        }
        return true;
    }

    private void PopulateQuestion()
    {
        Questions question = questionManager.Get(QuestionID);

        lblQuestionTitle.Text = question.Question;
        Page.Title = AppUtil.GetPageTitle("Question Details : " + question.Question);

        rdoA.Text = question.AnswerA;
        rdoB.Text = question.AnswerB;
        rdoC.Text = question.AnswerC;
        rdoD.Text = question.AnswerD;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string selectedAnswer = GetAnswer();
        if (selectedAnswer.Length == 0)
        {
            return;
        }
        Questions question = questionManager.Get(QuestionID);
        Answers answer = GetAnswer(question);
        AnswerTotal answerTotal = answerTotalManager.Get(question.QuestionID);
        answerTotal = ModifyAnswerTotal(answer,answerTotal);

        answerManager.SaveOrUpdate(answer);
        answerTotalManager.SaveOrUpdate(answerTotal);
        string questionDetailsPage = string.Format("QuestionDetails.aspx?QuestionID={0}&ShowRating=1&Correct={1}", question.QuestionID,answer.Correct);
        Response.Redirect(questionDetailsPage);
        
    }

    private Answers GetAnswer(Questions question)
    {
        string selectedAnswer = GetAnswer();

        Answers answer = new Answers();
        answer.QuestionID = question.QuestionID;
        answer.UserID = SessionCache.CurrentUser.Author_ID;
        answer.Answer = selectedAnswer;
        answer.TimeStamp = DateTime.Now;

        //===========================================
        answer.Time = GetTime();  //Need to change with the actual time//int.Parse(txtTime.Text);
        //=============================================
        answer.Correct = selectedAnswer == question.CorrectAnswer ? 1 : 0;
        answer.CorrectAnswer = question.CorrectAnswer;

        return answer;
    }

    private int GetTime()
    {
        string strTime = txtTime.Text;
        int Minutes = Convert.ToInt32(strTime.Substring(0,2));
        int Seconds = Convert.ToInt32(strTime.Substring(3,2));
        return (Minutes * 60) + Seconds;
    }

    private AnswerTotal ModifyAnswerTotal(Answers answer, AnswerTotal answerTotal)
    {
        if(answer.Answer == "A")
        {
            answerTotal.A++;
        }
        if (answer.Answer == "BA")
        {
            answerTotal.B++;
        }
        if (answer.Answer == "C")
        {
            answerTotal.C++;
        }
        if (answer.Answer == "D")
        {
            answerTotal.D++;
        }

        answerTotal.Total++;

        return answerTotal;
            //UPDATE tbl_AnswerTotal SET [" & varAnswer & "] = [" & varAnswer & "] +1, [Total] = [Total] + 1 WHERE [QuestionID]=" & varID & ";"
    }

    private string GetAnswer()
    {
        string answer = string.Empty;

        if (rdoA.Checked) return "A";
        if (rdoB.Checked) return "B";
        if (rdoC.Checked) return "C";
        if (rdoD.Checked) return "D";

        return answer;
    }
}
