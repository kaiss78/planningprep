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

public partial class Pages_Public_FAQ : System.Web.UI.Page
{
    private int _PrevCategoryID = 0;
    private IList<FaqCategory> _Categories;
    private IList<Faq> _Questions;

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("FAQ");
        if (!IsPostBack)
        {
            BindFaqQuestions();
        }
    }

    private void BindFaqQuestions()
    {
        FaqManager manager = new FaqManager();
        _Questions = manager.GetAllFaqSortByCategory();
        FaqCategoryManager categoryManager = new FaqCategoryManager();
        _Categories = categoryManager.GetList();
        var sortedCategories = (from P in _Categories
                                select P).OrderBy(P => P.Category);

        rptCategoryList.DataSource = sortedCategories.ToList();
        rptCategoryList.DataBind();

        rptFaqList.DataSource = _Questions;
        rptFaqList.DataBind();
    }
    protected string GetCategoryTitle(int categoryID)
    {
        var category = (from P in _Categories
                        where P.FaqCatID == categoryID
                        select P).Single();
        return category == null ? String.Empty : category.Category;
    }
    protected bool HasCategoryContainsQuestion(int faqCategoryId)
    {
        var faq = from P in _Questions
                  where P.FaqCatID == faqCategoryId
                  select P;
        if (faq == null || faq.Count() == 0)
            return false;
        return true;        
    }

    protected void rptCategoryList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        FaqCategory category = e.Item.DataItem as FaqCategory;
        if (HasCategoryContainsQuestion(category.FaqCatID))
        {
            HyperLink hplCategory = e.Item.FindControl("hplCategory") as HyperLink;
            hplCategory.Text = AppUtil.Encode(category.Category);
            hplCategory.NavigateUrl = String.Format("#{0}_{0}", category.FaqCatID);
        }
        else
            e.Item.Visible = false;
    }

    protected void rptFaqList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Faq faq = e.Item.DataItem as Faq;
        if (faq.FaqCatID != _PrevCategoryID)
        {
            HtmlGenericControl divCategoryHeading = e.Item.FindControl("divCategoryHeading") as HtmlGenericControl;
            divCategoryHeading.InnerHtml = String.Format("<a name='#{0}_{0}'>{1}</a>", faq.FaqCatID, GetCategoryTitle(faq.FaqCatID));
            divCategoryHeading.Visible = true;
            _PrevCategoryID = faq.FaqCatID;
        }
        HtmlGenericControl divQuestion = e.Item.FindControl("divQuestion") as HtmlGenericControl;
        divQuestion.InnerHtml = String.Format("<b/>{0}</b>", faq.Question);
        HtmlGenericControl divAnswer = e.Item.FindControl("divAnswer") as HtmlGenericControl;
        divAnswer.InnerHtml = faq.Answer;
    }
}
