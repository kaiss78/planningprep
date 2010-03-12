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
using System.Collections.Generic;

public partial class Pages_Member_QuestionDetails : System.Web.UI.Page
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

    private void PopulateQuestion()
    {
        Questions question = questionManager.Get(QuestionID);
        
        lblQuestionTitle.Text = question.Question;
        Page.Title = AppUtil.GetPageTitle("Question Details : " + question.Question); 
        
        lblA.Text = question.AnswerA;
        lblB.Text = question.AnswerB;
        lblC.Text = question.AnswerC;
        lblD.Text = question.AnswerD;

        lblQuestionDetails.Text = question.Explanation;

        IList<QuestionLink> links = questionManager.GetQuestionLinks(QuestionID);
        rptQuestionLinks.DataSource = links;
        rptQuestionLinks.DataBind();

        chartForQuestion.QuestionID = QuestionID;

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
    protected void rptQuestionLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            HyperLink hlinkQuestionLink = (HyperLink)e.Item.FindControl("hlinkQuestionLink");
            QuestionLink link = e.Item.DataItem as QuestionLink;
            hlinkQuestionLink.NavigateUrl = link.Link;
            hlinkQuestionLink.Text = link.LinkTitle;

            Label lblQuestionLinkDescription = (Label)e.Item.FindControl("lblQuestionLinkDescription");
            lblQuestionLinkDescription.Text = link.LinkDescription;
        }
    }
}
