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
    int QuestionRated;
    protected int _QuestionID;

    public int QuestionID
    {
        get { return _QuestionID; }
        set { _QuestionID = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        QuestionRated = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.QIESTION_RATED);
        if (QuestionRated == 1)
        {
            divRated.Visible = true;
            divRate.Visible = false;
        }
        else
        {
            divRated.Visible = false;
            divRate.Visible = true;
        }
    }

    protected void btnSubmitRate_Click(object sender, EventArgs e)
    {
        if (rdoRating.SelectedIndex < 0)
        {
            return;
        }
        int selcetedRating = int.Parse(rdoRating.SelectedValue);
        Questions question = questionManager.Get(QuestionID);

        question.RateTotal += selcetedRating;
        question.RateCount++;
        question.Rating = (float)question.RateTotal / (float)question.RateCount;

        questionManager.SaveOrUpdate(question);

        string questionDetailsPage = string.Format("~/Pages/Member/QuestionDetails.aspx?QuestionID={0}&Rated=1&ShowNextQuestion=1", question.QuestionID);
        Response.Redirect(questionDetailsPage);
    }
}
