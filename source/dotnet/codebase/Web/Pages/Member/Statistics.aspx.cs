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
using App.Models.Exams;
using App.Domain.Exams;
using System.Collections.Generic;
using System.Text;
using App.Models.Users;

public partial class Pages_Member_Statistics : BasePage
{
    private int _UserID = 0;
    private bool _IsFilterByDate = false;
    private DateTime _FilterDate = DateTime.Now;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle(SessionCache.CurrentUser.Username);
        _UserID = SessionCache.CurrentUser.Author_ID;
        if (!IsPostBack)
        {
            BindDayAndYearDropdownLists();
            BindOverallStatistics();
            BindStatisticsByCategory();
        }        
    }

    private void BindDayAndYearDropdownLists()
    {       
        int counter;
        for (counter = 1; counter <= 31; counter++)
        {
            ddlDay.Items.Add(new ListItem(counter.ToString(), counter.ToString()));
        }

        int starter = DateTime.Now.AddYears(-7).Year;
        counter = DateTime.Now.AddYears(3).Year;
        while (counter >= starter )
        {
            ddlYear.Items.Add(new ListItem(counter.ToString(), counter.ToString()));
            counter--;
        }
        ddlMonth.SelectedValue = DateTime.Today.Month.ToString();
        ddlDay.SelectedValue = DateTime.Today.Day.ToString();
        ddlYear.SelectedValue = DateTime.Today.Year.ToString();
    }

    protected void BindOverallStatistics()
    {
        ExamStatisticManager manager = new ExamStatisticManager();
        IList<ExamStatistic> statistics = manager.GetStatisticsForHistoryTheoryLaw(_UserID, _IsFilterByDate, _FilterDate);
        ExamStatistic stat = null;
        if(statistics != null && statistics.Count > 0)
            stat = statistics[0];

        PlanningPrepUser user = SessionCache.CurrentUser;
        ltrUserName.Text = user.Username;
        ltrFullName.Text = String.Format("{0} {1}", AppUtil.Encode(user.FirstName), AppUtil.Encode(user.LastName));
        ltrLastLogin.Text = user.LastLogin.ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY_WITH_TIME);
        ltrNumberOfLogin.Text = user.LoginNumber.ToString();
        ltrEmail.Text = AppUtil.Encode(user.Author_email);
        ltrQuestionsTaken.Text = stat == null ? "0" : stat.Taken.ToString();
        ltrCorrectAnswers.Text = stat == null ? "0" : stat.Correct.ToString();
        ltrTotalTime.Text = stat == null ? "0" : stat.TotalTime.ToString();
        
        double percent = 0;
        if(stat != null)
            percent = (Convert.ToDouble(stat.Correct) / Convert.ToDouble(stat.Taken)) * 100;
        
        ltrPercentCorrect.Text = String.Format(AppConstants.ValueOf.DECIMAL_FORMAT, percent);
        
        double timePerQuestion = 0;
        if(stat != null)
            timePerQuestion = Convert.ToDouble(stat.TotalTime) / Convert.ToDouble(stat.Taken) ;

        ltrTimePerQuestion.Text = String.Format(AppConstants.ValueOf.DECIMAL_FORMAT, timePerQuestion);
    }

    protected void BindStatisticsByCategory()
    {        
        StringBuilder sb = new StringBuilder(100);

        ExamStatisticManager manager = new ExamStatisticManager();
        IList<ExamStatistic> statistics = manager.GetStatisticsForHistoryTheoryLaw(_UserID, _IsFilterByDate, _FilterDate);
        sb.Append(GetStatisticsHtml(statistics, "History, Theory & Law"));

        statistics = manager.GetStatisticsForTrendsIssues(_UserID, _IsFilterByDate, _FilterDate);
        sb.Append(GetStatisticsHtml(statistics, "Trends & Issues"));

        statistics = manager.GetStatisticsForPlanMaking(_UserID, _IsFilterByDate, _FilterDate);
        sb.Append(GetStatisticsHtml(statistics, "Plan Making"));

        statistics = manager.GetStatisticsForFunctionalTopics(_UserID, _IsFilterByDate, _FilterDate);
        sb.Append(GetStatisticsHtml(statistics, "Functional Topics"));

        statistics = manager.GetStatisticsForPlanImplementation(_UserID, _IsFilterByDate, _FilterDate);
        sb.Append(GetStatisticsHtml(statistics, "Plan Implementation"));

        statistics = manager.GetStatisticsForEthics(_UserID, _IsFilterByDate, _FilterDate);
        sb.Append(GetStatisticsHtml(statistics, "Ethics"));

        divCategoryContainer.InnerHtml = sb.ToString();
    }
    protected String GetStatisticsHtml(IList<ExamStatistic> statistics, String title)
    {       
        String Html = @"<div class='categorycontainer'>
                        <b>{0}</b><br/>
                        Questions Taken: {1}<br />
                        Correct Answers: {2}<br />
                        Percent Correct: {3}%
                    </div>";
        if (statistics != null && statistics.Count > 0)
        {
            ExamStatistic stat = statistics[0];
            double percentage = (Convert.ToDouble(stat.Correct) / Convert.ToDouble(stat.Taken)) * 100;
            return String.Format(Html, title, stat.Taken, stat.Correct, String.Format(AppConstants.ValueOf.DECIMAL_FORMAT, percentage));
        }
        else        
            return String.Format(Html, title, 0, 0, 0);
        
    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            _IsFilterByDate = true;
            _FilterDate = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlDay.SelectedValue));
            BindOverallStatistics();
            BindStatisticsByCategory();
        }
    }
}
