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

public partial class Pages_Admin_EditFaqCategory : System.Web.UI.Page
{
    private int _CategoryID;
    protected void Page_Load(object sender, EventArgs e)
    {
        _CategoryID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.ID);
        if (_CategoryID > 0)
        {
            Page.Title = AppUtil.GetPageTitle("Edit FAQ Category");
            divHeading.InnerHtml = "Edit FAQ Category";
        }
        else
            Page.Title = "Add New FAQ Category";

        if (!IsPostBack)
        {
            BindCategory();
        }

    }

    protected void BindCategory()
    {
        if (_CategoryID > 0)
        {
            App.Domain.FAQ.FaqCategoryManager manager = new App.Domain.FAQ.FaqCategoryManager();
            FaqCategory category = manager.Get(_CategoryID);
            if (category == null)
            {
                pnlDetails.Visible = false;
                AppUtil.ShowMessageBox(divMessage, "Sorry! Requested FAQ Category was not found in the system.", true);
            }
            else
            {
                txtCategory.Text = category.Category;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SaveCategory();
            Response.Redirect(AppConstants.Pages.FAQ_CATEGORY_LIST, false);
            return;
        }
    }

    private void SaveCategory()
    {
        App.Domain.FAQ.FaqCategoryManager manager = new App.Domain.FAQ.FaqCategoryManager();
        FaqCategory category = null;
        if (_CategoryID == 0)
            category = new FaqCategory();
        else
            category = manager.Get(_CategoryID);

        if (category != null)
        {
            category.Category = txtCategory.Text.Trim();
            category.CatOrder = 5; //This is found hard coded in the old ASP Code
            category.EnteredBy = SessionCache.CurrentUser.Username;
            category.TimeStamp = DateTime.Now;

            manager.SaveOrUpdate(category);
        }
    }
}
