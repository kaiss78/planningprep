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

public partial class UserControls_RateQuestion : BaseUserControl
{
    QuestionsManager questionManager = new QuestionsManager();
    int ShowNextQuestion;
    public int QuestionID
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        ShowNextQuestion = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.SHOW_NEXT_QUESTION);
        if (ShowNextQuestion == 1)
        {
            divRated.Visible = true;
        }
        else
        {
            divRated.Visible = false;
        }
    }

    protected void btnSubmitRate_Click(object sender, EventArgs e)
    {
        int selcetedRating = int.Parse(rdoRating.SelectedValue);
        Questions question = questionManager.Get(QuestionID);

        question.RateTotal += selcetedRating;
        question.RateCount++;
        question.Rating = (float)question.RateTotal / (float)question.RateCount;

        questionManager.SaveOrUpdate(question);

        string questionDetailsPage = string.Format("~/Pages/Member/QuestionDetails.aspx?QuestionID={0}&ShowNextQuestion=1", question.QuestionID);
        Response.Redirect(questionDetailsPage);
    }
}
