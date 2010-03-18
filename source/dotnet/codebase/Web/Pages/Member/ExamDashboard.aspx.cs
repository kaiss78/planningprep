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
using App.Domain.Exams;
using App.Models.Exams;
using System.Collections.Generic;
using App.Domain.UserExams;
using App.Models.UserExams;

public partial class Pages_Private_ExamDashboard : BasePage
{
    ExamManager examManager = new ExamManager();
    UserExamManager userExamManager = new UserExamManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Exam");
        PopulateExamInfo();
    }

    private void PopulateExamInfo()
    {
        IList<Exam> allExams = examManager.GetList();
        rptExams.DataSource = allExams;
        rptExams.DataBind();
    }
    protected void rptExams_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            Label lblExamName = (Label)item.FindControl("lblExamName");
            Exam exam = item.DataItem as Exam;
            lblExamName.Text = exam.Title;

            Panel pnlExamSession = (Panel)item.FindControl("pnlExamSession");
            pnlExamSession.Attributes["ExamSessionID"] = "Exam" + exam.Id.ToString();
            pnlExamSession.Style["display"] = "none";
            

            Label lblExpandCollapse = (Label)item.FindControl("lblExpandCollapse");
            lblExpandCollapse.Text = "+";
            lblExpandCollapse.Attributes["ExamSessionID"] = "Label" + exam.Id.ToString();

            Panel pnlExam = (Panel)item.FindControl("pnlExam");
            pnlExam.Attributes["onclick"] = " ExpandCollapse(" + exam.Id + ")";
            pnlExam.Style["cursor"] = "pointer";

            IList<UserExam> userExams = userExamManager.GetUserExamByExamAndUser(exam.ExamID,SessionCache.CurrentUser.Author_ID);
            if (userExams != null && userExams.Count > 0)
            {
                Repeater rptExamSessions = (Repeater)item.FindControl("rptExamSessions");

                rptExamSessions.DataSource = userExams;
                rptExamSessions.DataBind();
            }

            HyperLink hlinkNewExamSession = (HyperLink)item.FindControl("hlinkNewExamSession");
            if (hlinkNewExamSession != null)
            {
                hlinkNewExamSession.NavigateUrl = string.Format("Exam.aspx?Action=New&ExamID={0}", exam.ExamID);
            }
        }

    }

    protected void rptExamSessions_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            UserExam userExam = item.DataItem as UserExam;

            Label lblExamSession = (Label)item.FindControl("LblExamSession");
            HyperLink hlinkFinishExam = (HyperLink)item.FindControl("hlinkFinishExam");
            string Action = userExam.EndDate == DateTime.MinValue?"Continue":"New";
            if (Action == "Continue")
            {
                hlinkFinishExam.NavigateUrl = string.Format("Exam.aspx?Action={0}&ExamSessionID={1}", Action, userExam.ExamSessionID);
                lblExamSession.Text = string.Format("You started this exam on {0} and it was never completed.", userExam.StartDate);
            }
            else
            {
                hlinkFinishExam.Text = "Click here to view your results.";
                hlinkFinishExam.NavigateUrl = string.Format("ExamResult.aspx?ExamSessionID={0}", userExam.ExamSessionID);
                lblExamSession.Text = string.Format("You started this exam on {0} and it was completed on {1}.", userExam.StartDate,userExam.EndDate);
            }
            
            
            
            
        }

    }
}
