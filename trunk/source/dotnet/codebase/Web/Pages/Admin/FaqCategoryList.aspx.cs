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
using App.Models.FAQ;
using App.Domain.FAQ;

public partial class Pages_Admin_FaqCategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("FAQ Category List");
        hplAddNewFAQCategory.NavigateUrl = AppConstants.Pages.EDIT_FAQ_CATEGORY;
        if (!IsPostBack)
        {
            BindCategoryList(1);
        }
    }
    protected void BindCategoryList(int pageNo)
    {
        int pageSize = ConfigReader.AdminFAQCategoryListSize;
        FaqCategoryManager manager = new FaqCategoryManager();
        IList<FaqCategory> categories = manager.GetPagedList(pageNo, pageSize);
        //int totalCount = manager.GetPagedList(1, int.MaxValue).Count;
        rptCategoryList.DataSource = categories;
        rptCategoryList.DataBind();     
    }
    protected void rptCategoryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            FaqCategory category = e.Item.DataItem as FaqCategory;

            HyperLink hplCategory = item.FindControl("hplCategory") as HyperLink;
            hplCategory.Text = AppUtil.Encode(category.Category); //AppUtil.Encode(question.Question);

            Label lblModified = item.FindControl("lblModified") as Label;
            lblModified.Text = category.TimeStamp.ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY);

            Label lblEnteredBy = item.FindControl("lblEnteredBy") as Label;
            lblEnteredBy.Text = AppUtil.Encode(category.EnteredBy);

            HyperLink hplEdit = item.FindControl("hplEdit") as HyperLink;
            hplEdit.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.EDIT_FAQ_CATEGORY, AppConstants.QueryString.ID, category.FaqCatID);
            hplCategory.NavigateUrl = hplEdit.NavigateUrl;
        }
    }
}
