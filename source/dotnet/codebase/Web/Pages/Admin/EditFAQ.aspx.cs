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

public partial class Pages_Admin_EditFAQ : BasePage
{
    private int _FaqID;

    protected void Page_Load(object sender, EventArgs e)
    {
        _FaqID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.ID);
        if (_FaqID > 0)
        {
            Page.Title = AppUtil.GetPageTitle("Edit Question in the FAQ Database");
            divHeading.InnerHtml = "Edit Question in the FAQ Database";
        }
        else
            Page.Title = AppUtil.GetPageTitle("Add New Question in the FAQ Database");

        if (!IsPostBack)
        {
            BindFaqCategory();
            BindFaq();
        }
    }

    private void BindFaq()
    {
        if (_FaqID > 0)
        {
            App.Domain.FAQ.FaqManager manager = new App.Domain.FAQ.FaqManager();
            App.Models.FAQ.Faq faq = manager.Get(_FaqID);
            if (faq == null)
            {
                pnlDetails.Visible = false;
                AppUtil.ShowMessageBox(divMessage, "Sorry! Requested FAQ Question was not found in the system.", true);
            }
            else
            {
                txtQuestion.Text = faq.Question;
                txtAnswer.Text = faq.Answer;
                ddlFaqCategory.SelectedValue = faq.FaqCatID.ToString();
            }
        }
    }

    protected void BindFaqCategory()
    {
        App.Domain.FAQ.FaqCategoryManager manager = new App.Domain.FAQ.FaqCategoryManager();
        IList<FaqCategory> categories = manager.GetList();
        ddlFaqCategory.DataSource = categories;
        ddlFaqCategory.DataValueField = "FaqCatID";
        ddlFaqCategory.DataTextField = "Category";
        ddlFaqCategory.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            SaveFaq();
            Response.Redirect(AppConstants.Pages.FAQ_LIST, false);
            return;
        }
    }

    private void SaveFaq()
    {
        App.Domain.FAQ.FaqManager manager = new App.Domain.FAQ.FaqManager();
        App.Models.FAQ.Faq faq = null;
        
        if (_FaqID == 0)
            faq = new Faq();
        else
            faq = manager.Get(_FaqID);

        if (faq != null)
        {
            faq.Question = txtQuestion.Text.Trim();
            faq.Answer = txtAnswer.Text.Trim();
            faq.FaqCatID = Convert.ToInt32(ddlFaqCategory.SelectedValue);
            faq.TimeStamp = DateTime.Now;
            faq.EnteredBy = SessionCache.CurrentUser.Username;
            
            //Save the Object
            manager.SaveOrUpdate(faq);
        }
    }
}
