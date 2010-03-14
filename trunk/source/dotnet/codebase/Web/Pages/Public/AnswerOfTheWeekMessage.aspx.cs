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
using System.Text;

public partial class Pages_Public_AnswerOfTheWeekMessage : BasePage
{
    protected int _QuestionID;    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Question of the Week");
        
        if (!IsPostBack)
        {
            BindQuestionData();
        }
    }

    protected void BindQuestionData()
    {
        int.TryParse(Request[AppConstants.QueryString.QUESTION_ID], out _QuestionID);
        App.Domain.Questions.QuestionsManager manager = new App.Domain.Questions.QuestionsManager();
        App.Models.Questions.Questions question = manager.Get(_QuestionID);
        if (question != null)
        {
            ucChart.QuestionID = question.QuestionID;
            ltrQuestion.Text = question.Question;
            String answer = Request[AppConstants.QueryString.ANSWER];
            if (String.Compare(question.CorrectAnswer, answer, true) == 0)
                ltrAnswer.Text = String.Format("Right, the correct answer is {0}", question.CorrectAnswer);
            else
                ltrAnswer.Text = String.Format("Wrong, the correct answer is {0}", question.CorrectAnswer);

            if (question.CorrectAnswer == "A")
                ltrAnswer.Text = String.Format("{0} ({1})", ltrAnswer.Text, question.AnswerA);
            else if (question.CorrectAnswer == "B")
                ltrAnswer.Text = String.Format("{0} ({1})", ltrAnswer.Text, question.AnswerB);
            else if (question.CorrectAnswer == "C")
                ltrAnswer.Text = String.Format("{0} ({1})", ltrAnswer.Text, question.AnswerC);
            else if (question.CorrectAnswer == "D")
                ltrAnswer.Text = String.Format("{0} ({1})", ltrAnswer.Text, question.AnswerD);

            ltrExplanation.Text = question.Explanation;

            App.Domain.Links.LinkManager linkManager = new App.Domain.Links.LinkManager();
            IList<App.Models.Links.Link> links = linkManager.GetLinksForQuestion(question.QuestionID);
            BuildHtmlForLinks(links);

        }
    }

    protected void BuildHtmlForLinks(IList<App.Models.Links.Link> links)
    {
        if (links != null & links.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (App.Models.Links.Link link in links)
            {
                sb.Append("<div style='margin-bottom:15px;'>");
                String url = String.Format("{0}?{1}={2}&{3}={4}", AppConstants.Pages.VISIT_FRAME, AppConstants.QueryString.LINK_ID, link.LinkID, AppConstants.QueryString.LINK, link.LinkOriginal);
                ///Pages/Public/VisitFrame.aspx?Link
                sb.AppendFormat("<a href='{0}' target='_blank'>{1}</a><br/>", url, link.LinkTitle);
                sb.Append(link.LinkDescription);
                sb.Append("</div>");                
            }
            ltrLinks.Text = sb.ToString();
        }
    }
}
