using System;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;

public partial class UserControl_Pager : BaseUserControl
{
    public delegate void PageChanged(object sender, PagerEventArgs e);
    public event PageChanged PageIndexChanged;
    //public event PagerDelegate.PageChanged PageChanged;
    private PagerEventArgs args;

    #region Public Properties [TotalRecord] [PageIndex] [PageSize]
    public int TotalRecord
    {
        get;
        set;
    }
    public int PageIndex
    {
        get;
        set;
    }
    public int PageSize
    {
        get;
        set;
    }
    #endregion Public Properties [TotalRecord] [PageIndex] [PageSize]

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    lblCurrentPage.Text = this.PageIndex.ToString();
        //    if(this.TotalRecord > 0 && this.PageSize > 0)
        //        BindPager();
        //}
    }
    public override void DataBind()
    {
        lblCurrentPage.Text = this.PageIndex.ToString();
        if (this.TotalRecord > 0 && this.PageSize > 0)
            BindPager();
        base.DataBind();
    }

    /// <summary>
    /// Binds The Pager Control For Favorite Groups
    /// </summary>
    /// <param name="totalRecord"></param>
    /// <param name="p"></param>
    //private void BindPager(int totalRecord, int pageNumber, int pageSize)
    private void BindPager()
    {
        int numberOfPageLinkToDisplay = 10;
        int totalPage = Convert.ToInt32(Math.Ceiling((double)this.TotalRecord / (double)this.PageSize));        
        if (totalPage > 1)
        {
            divPageCount.InnerHtml = String.Format("Showing page {0} of {1}", this.PageIndex, totalPage);
            List<DataPage> pages = new List<DataPage>();
            int startPage = 0;
            if ((this.PageIndex - (numberOfPageLinkToDisplay / 2)) <= 0)
                startPage = 1;
            else
                startPage = this.PageIndex - (numberOfPageLinkToDisplay / 2);

            for (int i = 1; i <= numberOfPageLinkToDisplay; i++)
            {
                if (startPage > totalPage)
                    break;
                DataPage page = new DataPage();
                page.PageNo = startPage;
                pages.Add(page);
                startPage++;
            }
            if (pages.Count > 0)
            {
                rptPages.DataSource = pages;
                rptPages.DataBind();
                divPager.Visible = true;
            }
            if (this.PageIndex == 1)
            {
                lnkPrevious.Visible = false;
                lblPrevious.Visible = true;
            }
            else
            {
                lnkPrevious.Visible = true;
                lblPrevious.Visible = false;
            }
            if (this.PageIndex == totalPage)
            {
                lnkNext.Visible = false;
                lblNext.Visible = true;
            }
            else
            {
                lnkNext.Visible = true;
                lblNext.Visible = false;
            }
        }
        else
        {
            divPager.Visible = false;
        }
    }

    protected void lnkNextPrevious_Click(object sender, EventArgs e)
    {
        args = new PagerEventArgs();        
        switch (((LinkButton)sender).ID)
        {
            case "lnkPrevious":
                args.PageIndex = Convert.ToInt32(lblCurrentPage.Text) - 1;
                break;
            case "lnkNext":
                args.PageIndex = Convert.ToInt32(lblCurrentPage.Text) + 1;
                break;
        }
        this.PageIndex = args.PageIndex;
        PropagatePageChangedEvent(args);
        
        ///Bind the Pager Again
        BindPager();
        lblCurrentPage.Text = args.PageIndex.ToString();
    }

    private void PropagatePageChangedEvent(PagerEventArgs args)
    {
        ///Propagate the Page Change Event
        if (PageIndexChanged == null)
            throw new Exception(String.Format("CustomPager {0} fired a PageChanged event which was not handled.", this.ID));
        else
            PageIndexChanged(this, args);
    }
    /// <summary>
    /// Pager Control Data Bound Event for Contacts
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        args = new PagerEventArgs();
        this.PageIndex = Convert.ToInt32(e.CommandArgument);
        args.PageIndex = this.PageIndex;
        lblCurrentPage.Text = this.PageIndex.ToString();
        PropagatePageChangedEvent(args);
    }
    /// <summary>
    /// Pager Control Data Bound Event for Groups
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rptPages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {        
        int pageNumber = 0;
        int.TryParse(lblCurrentPage.Text, out pageNumber);

        DataPage page = (DataPage)e.Item.DataItem;
        if (page.PageNo == pageNumber)
        {
            LinkButton lnkPage = e.Item.FindControl("lnkPage") as LinkButton;
            Label lblListingCurrentPage = e.Item.FindControl("lblListingCurrentPage") as Label;
            lnkPage.Visible = false;
            lblListingCurrentPage.Text = page.PageNo.ToString();
            lblListingCurrentPage.Visible = true;
            HtmlGenericControl divPagerContainer = e.Item.FindControl("divPagerContainer") as HtmlGenericControl;
            divPagerContainer.Attributes["class"] = String.Format("CurrentPage {0}", divPagerContainer.Attributes["class"]);
        }
    }
}

/// <summary>
/// Summary description for PagerEventArgs
/// </summary>
public class PagerEventArgs : EventArgs
{
    public int PageIndex
    {
        get;
        set;
    }
    //public int PageSize
    //{
    //    get;
    //    set;
    //}
    //public int TotalPages
    //{
    //    get;
    //    set;
    //}
}

/// <summary>
/// This Class is used to bind pager control
/// </summary>
public class DataPage
{
    private int _pageNo;
    public int PageNo
    {
        get { return _pageNo; }
        set { _pageNo = value; }
    }
}
