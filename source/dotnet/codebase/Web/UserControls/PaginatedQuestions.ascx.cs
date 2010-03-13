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
using System.Collections.Generic;

public partial class UserControls_PaginatedQuestions : System.Web.UI.UserControl
{
    public bool ShowEditLink
    {
        get;
        set;
    }

    public bool ShowLastModifiedDate
    {
        get;
        set;
    }

    public bool ShowDetailsLink
    {
        get;
        set;
    }

    public string Keyword
    {
        get;
        set;
    }

    public string Category
    {
        get;
        set;
    }

    public bool AnswerQuestion
    {
        get;
        set;
    }

    public bool ShowQuestionsForAnswerMode
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Question List");
        if (!IsPostBack)
        {
            //hplAddNewQuestion.NavigateUrl = AppConstants.Pages.EDIT_QUESTION;
            BindQuestionList(1);
        }
    }

    protected void BindQuestionList(int pageNo)
    {
        int pageSize = ConfigReader.AdminQuestionListSize;
        App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
        List<Questions> questions = null;
        if (ShowQuestionsForAnswerMode)
        {
            bool filter = false;
            if (SessionCache.CurrentUser != null)
            {
                if (SessionCache.CurrentUser.Mode == "Filtered")
                {
                    filter = true;
                }
            }
            questions = manager.GetPagedListByKeywordOrCategory(pageNo, pageSize, Keyword, Category,SessionCache.CurrentUser.Author_ID,filter).ToList();
        }
        else
        {
            questions = manager.GetPagedList(pageNo, pageSize).ToList();
        }
        int totalRecord = manager.GetPagedList(1, int.MaxValue).Count;
        rptQuestionList.DataSource = questions;
        rptQuestionList.DataBind();
        BindPagerControl(pageNo, totalRecord, pageSize);
    }
    protected void BindPagerControl(int pageNo, int totalRecord, int pageSize)
    {
        ucPager.TotalRecord = totalRecord;
        ucPager.PageIndex = pageNo;
        ucPager.PageSize = pageSize;
        ucPager.DataBind();
    }
    protected void ucPager_PageIndexChanged(object sender, PagerEventArgs e)
    {
        //SessionCache.InvoiceSearchProperties.PageIndex = e.PageIndex;
        BindQuestionList(e.PageIndex);
    }
    protected void rptQuestionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            App.Models.Questions.Questions question = e.Item.DataItem as App.Models.Questions.Questions;

            Label lblQuestion = e.Item.FindControl("lblQuestion") as Label;
            lblQuestion.Text = question.Question; //AppUtil.Encode(question.Question);

            Label lblExplanation = e.Item.FindControl("lblExplanation") as Label;
            lblExplanation.Text = AppUtil.Encode(question.ModifiedWhen.ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY));

            if (!ShowLastModifiedDate)
            {
                lblExplanation.Visible = false;
                lblLastModified.Visible = false;
            }

            HyperLink hplEdit = e.Item.FindControl("hplEdit") as HyperLink;
            hplEdit.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.EDIT_QUESTION, AppConstants.QueryString.QUESTION_ID, question.QuestionID);

            HyperLink hlinkQuestion = e.Item.FindControl("hlinkQuestion") as HyperLink;
            if (AnswerQuestion)
            {
                hlinkQuestion.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.ANSWER_QUESTION, AppConstants.QueryString.QUESTION_ID, question.QuestionID);
            }
            else
            {
                hlinkQuestion.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.QUESTION_DETAILS, AppConstants.QueryString.QUESTION_ID, question.QuestionID);
            }
            hlinkQuestion.Text = question.Question;

            if (!ShowEditLink)
            {
                hplEdit.Visible = false;
                lblEdit.Visible = false;
            }

            if (ShowDetailsLink)
            {
                hlinkQuestion.Visible = true;
                lblQuestion.Visible = false;
            }
            else
            {
                hlinkQuestion.Visible = false;
                lblQuestion.Visible = true;
            }
        }
    }
}
