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
        if (!IsPostBack)
        {
            BindQuestionList();
        }
    }

    protected void BindQuestionList()
    {
        App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
        List<Questions> questions = manager.GetPagedList(1, 10).ToList();
        rptQuestionList.DataSource = questions;
        rptQuestionList.DataBind();
    }
    protected void rptQuestionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        App.Models.Questions.Questions question = e.Item.DataItem as App.Models.Questions.Questions;
        HyperLink hplEdit = e.Item.FindControl("hplEdit") as HyperLink;
        hplEdit.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.EDIT_QUESTION, AppConstants.QueryString.QUESTION_ID, question.QuestionID);
    }
}
