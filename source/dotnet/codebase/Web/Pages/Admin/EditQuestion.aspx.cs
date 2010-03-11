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

public partial class Pages_Private_Admin_EditQuestion : System.Web.UI.Page
{
    private int _QuestionID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        BindInitilizerControls();
        if (!IsPostBack)
        {
            BindQuestionData(_QuestionID);
        }
    }    

    protected void BindInitilizerControls()
    {
        int.TryParse(Request[AppConstants.QueryString.QUESTION_ID], out _QuestionID);

        if (_QuestionID > 0)
        {
            Page.Title = AppUtil.GetPageTitle("Edit Question");
            ltrHeading.Text = "Edit Question";
        }
        else
        {
            Page.Title = AppUtil.GetPageTitle("Add New Question");
            ltrHeading.Text = "Add New Question";
        }

        hplQuestionList.NavigateUrl = AppConstants.Pages.MANAGE_QUESTIONS;
    }

    private void BindQuestionData(int questionID)
    {
        App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
        App.Models.Questions.Questions question = null;        
        question = manager.Get(_QuestionID);
        if (question != null)
        {
            txtQuestion.Text = question.Question;
            txtAnswerA.Text = question.AnswerA;
            txtAnswerB.Text = question.AnswerB;
            txtAnswerC.Text = question.AnswerC;
            txtAnswerD.Text = question.AnswerD;
            txtExplanation.Text = question.Explanation;
            ddlCorrectAnswer.SelectedValue = question.CorrectAnswer;
            chkIsFunctionalTopics.Checked = question.FunctionalTopics;
            chkIsHistoryTheoryLaw.Checked = question.HistoryTheoryLaw;
            chkIsEthics.Checked = question.Ethics;
            chkIsPlanMaking.Checked = question.PlanMaking;
            chkIsPlanImplementation.Checked = question.PlanImplementation;
        }        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SaveQuestion();
        }
    }
    protected void SaveQuestion()
    {
        App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
        App.Models.Questions.Questions question = null;
        if (_QuestionID > 0)
        {
            question = manager.Get(_QuestionID);            
        }
        else
        {
            question = new App.Models.Questions.Questions();
        }
        PopulateObject(question);
        manager.SaveOrUpdate(question);
    }

    private void PopulateObject(App.Models.Questions.Questions question)
    {
        question.Question = txtQuestion.Text;
        question.AnswerA = txtAnswerA.Text;
        question.AnswerB = txtAnswerB.Text;
        question.AnswerC = txtAnswerC.Text;
        question.AnswerD = txtAnswerD.Text;
        question.CorrectAnswer = ddlCorrectAnswer.SelectedValue;
        question.Explanation = txtExplanation.Text;
        question.FunctionalTopics = chkIsFunctionalTopics.Checked;
        question.HistoryTheoryLaw = chkIsHistoryTheoryLaw.Checked;
        question.Ethics = chkIsEthics.Checked;
        question.PlanMaking = chkIsPlanMaking.Checked;
        question.PlanImplementation = chkIsPlanImplementation.Checked;
        question.When = DateTime.Now;
        question.WrittenBy = "User First Name and Last Name";
    }
}
