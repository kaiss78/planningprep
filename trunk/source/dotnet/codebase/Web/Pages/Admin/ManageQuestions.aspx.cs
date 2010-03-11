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
using System.Collections.Generic;
using App.Models.Questions;

public partial class Admin_ManageQuestions : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Manage Questions");
        if (!IsPostBack)
        {
            hplAddNewQuestion.NavigateUrl = AppConstants.Pages.EDIT_QUESTION;
            BindQuestionList(1);
        }
    }

    protected void BindQuestionList(int pageNo)
    {
        int pageSize = ConfigReader.AdminQuestionListSize;
        App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
        List<Questions> questions = manager.GetPagedList(pageNo, pageSize).ToList();
        int totalRecord = manager.GetPagedList(1, int.MaxValue).Count;
        rptQuestionList.DataSource = questions;
        rptQuestionList.DataBind();
        BindPagerControl(pageNo, totalRecord, pageSize);
    }
    protected void BindPagerControl(int pageNo, int totalRecord, int pageSize)
    {
        ucPager.TotalRecord = totalRecord ;
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
        App.Models.Questions.Questions question = e.Item.DataItem as App.Models.Questions.Questions;

        Label lblQuestion = e.Item.FindControl("lblQuestion") as Label;
        lblQuestion.Text = question.Question; //AppUtil.Encode(question.Question);

        Label lblExplanation = e.Item.FindControl("lblExplanation") as Label;
        lblExplanation.Text = AppUtil.Encode(question.ModifiedWhen.ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY));
        

        HyperLink hplEdit = e.Item.FindControl("hplEdit") as HyperLink;
        hplEdit.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.EDIT_QUESTION, AppConstants.QueryString.QUESTION_ID, question.QuestionID);
    }
}
