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
using App.Models.FAQ;
using System.Collections.Generic;

public partial class Pages_Admin_FAQList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("FAQ Question List");
        SerDefaultValues();
        if (!IsPostBack)
        {
            BindFAQQuestionList(1);
        }
    }

    protected void BindFAQQuestionList(int pageNo)
    {
        int pageSize = ConfigReader.AdminFAQQuestionListSize;
        App.Domain.FAQ.FaqManager manager = new App.Domain.FAQ.FaqManager(); 
        IList<Faq> questions = manager.GetPagedList(pageNo, pageSize);
        int totalCount = manager.GetPagedList(1, int.MaxValue).Count;
        rptQuestionList.DataSource = questions;
        rptQuestionList.DataBind();
        BindPagerControl(pageNo, totalCount, pageSize);
    }
    protected void BindPagerControl(int pageNo, int totalRecord, int pageSize)
    {
        ucPager.TotalRecord = totalRecord;
        ucPager.PageIndex = pageNo;
        ucPager.PageSize = pageSize;
        ucPager.DataBind();
    }

    protected void SerDefaultValues()
    {
        hplAddNewFAQ.NavigateUrl = AppConstants.Pages.EDIT_FAQ;
        hplManageFAQCategory.NavigateUrl = AppConstants.Pages.FAQ_CATEGORY_LIST;
    }
    protected void ucPager_PageIndexChanged(object sender, PagerEventArgs e)
    {
        BindFAQQuestionList(e.PageIndex);
    }
    protected void rptQuestionList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            App.Models.FAQ.Faq question = e.Item.DataItem as App.Models.FAQ.Faq;

            HyperLink hplQuestion = item.FindControl("hplQuestion") as HyperLink;
            hplQuestion.Text = AppUtil.FormatText(question.Question); //AppUtil.Encode(question.Question);

            Label lblModified = item.FindControl("lblModified") as Label;
            lblModified.Text = question.TimeStamp.ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY);

            HyperLink hplEdit = item.FindControl("hplEdit") as HyperLink;
            hplEdit.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.EDIT_FAQ, AppConstants.QueryString.ID, question.FaqID);
            hplQuestion.NavigateUrl = hplEdit.NavigateUrl;
        }
    }
}
