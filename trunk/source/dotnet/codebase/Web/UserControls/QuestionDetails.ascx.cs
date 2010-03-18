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
    protected bool _ShowComments = true;
    #region Properties
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

    public bool Rated
    {
        get;
        set;
    }

    public bool ShowNextQuestion
    {
        get;
        set;
    }

    public bool Correct
    {
        get;
        set;
    }
    public bool ShowComments
    {
        get { return _ShowComments; }
        set { _ShowComments = value; }
    }
    #endregion Properties

    protected void Page_Load(object sender, EventArgs e)
    {
        if (QuestionID == 0)
        {
            return;
        }

        rateQuestion.Visible = true;

        if (ShowRating || Rated)
        {
            rateQuestion.QuestionID = QuestionID;
            divQuestion.Visible = false;
            divResult.Visible = true;
            ShowNextQuestion = true;
        }
        else
        {
            divQuestion.Visible = true;
            divResult.Visible = false;
            rateQuestion.Visible = false;
            ShowNextQuestion = false;
        }

        Questions question = null;

        if (ShowNextQuestion)
        {
            question = SessionCache.GetNextQuestion(QuestionID);
            if (question != null)
            {
                divNextQuestion.Visible = true;
                hlinkNextQuestion.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.ANSWER_QUESTION, AppConstants.QueryString.QUESTION_ID, question.QuestionID);
            }
            else
            {
                hlinkNextQuestion.NavigateUrl = String.Format(AppConstants.Pages.QUESGION_SEARCH);
            }
        }
        else
        {
            divNextQuestion.Visible = false;
        }
        
        question = questionManager.Get(QuestionID);
        

        if (question != null)
        {
            PopulateQuestion(question);
        }
    }

    private string GetCorrectAnswer(Questions question)
    {
        string option = question.CorrectAnswer;

        if (option == "A")
        {
            return question.AnswerA;
        }
        if (option == "B")
        {
            return question.AnswerB;
        }
        if (option == "C")
        {
            return question.AnswerC;
        }
        if (option == "D")
        {
            return question.AnswerD;
        }
        return question.AnswerA;
    }

    private void PopulateQuestion(Questions question)
    {
        lblQuestionTitle.Text = question.Question;
        lblQuestion.Text = question.Question;
        if (Correct)
        {
            lblResult.Text = "Right, the correct answer is " + question.CorrectAnswer;
            lblResult.CssClass = "right";
            lblResultDetails.Text = string.Format("You are Right, the correct answer is {0} ({1})." , question.CorrectAnswer , GetCorrectAnswer(question));
        }
        else
        {
            lblResult.Text = "Wrong, the correct answer is " + question.CorrectAnswer;
            lblResult.CssClass = "wrong";
            lblResultDetails.Text = string.Format("You are Wrong, the correct answer is {0} ({1})." , question.CorrectAnswer , GetCorrectAnswer(question));
        }
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
        if (this.ShowComments)
        {
            ucCommenting.QuestionID = QuestionID;
            ucCommenting.Visible = true;
        }

    }

    protected void rptQuestionLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            HyperLink hlinkQuestionLink = (HyperLink)e.Item.FindControl("hlinkQuestionLink");
            QuestionLink link = e.Item.DataItem as QuestionLink;
            
            String url = String.Format("{0}?{1}={2}&{3}={4}", AppConstants.Pages.VISIT_FRAME, AppConstants.QueryString.LINK_ID, link.LinkID, AppConstants.QueryString.LINK, Server.UrlEncode(link.Link));
            hlinkQuestionLink.NavigateUrl = url;
            hlinkQuestionLink.Text = link.LinkTitle;

            Label lblQuestionLinkDescription = (Label)e.Item.FindControl("lblQuestionLinkDescription");
            lblQuestionLinkDescription.Text = link.LinkDescription;
        }
    }


}
