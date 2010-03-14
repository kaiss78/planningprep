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
using App.Models.Questions;
using App.Domain.Questions;
using System.Collections.Generic;

public partial class UserControls_QuestionDetails : BaseUserControl
{
    QuestionsManager questionManager = new QuestionsManager();

    public int QuestionID
    {
        get;
        set;
    }

    public bool ShowRating
    {
        get;
        set;
    }

    public bool ShowNextQuestion
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (QuestionID == 0)
        {
            return;
        }
        if (ShowRating)
        {
            rateQuestion.QuestionID = QuestionID;
        }
        else
        {
            rateQuestion.Visible = false;
        }

        if (ShowNextQuestion)
        {
            rateQuestion.Visible = false;
            divNextQuestion.Visible = true;
        }
        else
        {
            divNextQuestion.Visible = false;
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
