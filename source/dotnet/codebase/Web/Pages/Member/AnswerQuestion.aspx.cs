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

public partial class Pages_Member_AnswerQuestion : BasePage
{
    int QuestionID;
    QuestionsManager questionManager = new QuestionsManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!LoadParams())
        {
            Response.Redirect("~/Error.aspx?ErrorCode=3");
            return;
        }

        PopulateQuestion();
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

        //lblQuestionDetails.Text = question.Explanation;

        //IList<QuestionLink> links = questionManager.GetQuestionLinks(QuestionID);
        //rptQuestionLinks.DataSource = links;
        //rptQuestionLinks.DataBind();

        //chartForQuestion.QuestionID = QuestionID;

    }

}
