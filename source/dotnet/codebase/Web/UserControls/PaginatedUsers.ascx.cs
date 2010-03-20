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
using App.Domain.Users;
using App.Models.Users;

public partial class UserControls_PaginatedUsers : BaseUserControl
{
    #region Properties
    public bool ShowEditLink
    {
        get;
        set;
    }

    public bool ShowLastModifiedDate
    {
        get;
        set;
    }

    public bool ShowUserName
    {
        get;
        set;
    }


    public bool ShowDetailsLink
    {
        get;
        set;
    }

    public string Keyword
    {
        get;
        set;
    }
    #endregion Propertiws

    private int PageSizeForGettingAllData = 100000000;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("User List");
        if (!IsPostBack)
        {
            //hplAddNewUser.NavigateUrl = AppConstants.Pages.EDIT_User;
            BindUserList(1);
        }
    }

    protected void BindUserList(int pageNo)
    {
        //Keyword = WebUtil.GetRequestParamValueInString(AppConstants.QueryString.User_KEYWORD);

        int pageSize = ConfigReader.AdminUserListSize;
        UserManager manager = new UserManager();
        List<PlanningPrepUser> Users = null;
        int totalRecord = 0;

        Users = manager.GetPagedList(pageNo, pageSize).ToList();
        totalRecord = manager.GetUserCount();

        if (Users == null || Users.Count == 0)
        {
            rptUserList.Visible = false;
            ucPager.Visible = false;
            lblNoUserFoundMessage.Visible = true;
        }
        else
        {
            rptUserList.DataSource = Users;
            rptUserList.DataBind();
            BindPagerControl(pageNo, totalRecord, pageSize);
        }
    }
    protected void BindPagerControl(int pageNo, int totalRecord, int pageSize)
    {
        ucPager.TotalRecord = totalRecord;
        ucPager.PageIndex = pageNo;
        ucPager.PageSize = pageSize;
        ucPager.DataBind();
    }
    protected void ucPager_PageIndexChanged(object sender, PagerEventArgs e)
    {
        //SessionCache.InvoiceSearchProperties.PageIndex = e.PageIndex;
        BindUserList(e.PageIndex);
    }
    protected void rptUserList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            PlanningPrepUser User = e.Item.DataItem as PlanningPrepUser;

            HtmlInputCheckBox chkSelectUser = e.Item.FindControl("chkSelectUser") as HtmlInputCheckBox;
            chkSelectUser.Value = User.Author_ID.ToString();

            Label lblUser = e.Item.FindControl("lblUser") as Label;
            lblUser.Text = string.Format("{0} {1}", User.FirstName,User.LastName); //AppUtil.Encode(User.User);


            HyperLink hplEdit = e.Item.FindControl("hplEdit") as HyperLink;
            hplEdit.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.EDIT_USERS, AppConstants.QueryString.USER_ID, User.Author_ID);

            HyperLink hlinkUser = e.Item.FindControl("hlinkUser") as HyperLink;
            
            hlinkUser.NavigateUrl = String.Format("{0}?{1}={2}", AppConstants.Pages.USER_DETAILS, AppConstants.QueryString.USER_ID, User.Author_ID);

            hlinkUser.Text = lblUser.Text;

            if (!ShowEditLink)
            {
                hplEdit.Visible = false;
            }

            if (ShowDetailsLink)
            {
                hlinkUser.Visible = true;
                lblUser.Visible = false;
            }
            else
            {
                hlinkUser.Visible = false;
                lblUser.Visible = true;
            }
        }
        else if (item.ItemType == ListItemType.Header)
        {
            if (!ShowUserName)
            {
                Label lblUserName = e.Item.FindControl("lblUserName") as Label;
                lblUserName.Visible = false;
            }

            if (!ShowLastModifiedDate)
            {
                Label lblLastModified = e.Item.FindControl("lblLastModified") as Label;
                lblLastModified.Visible = false;
            }
            if (!ShowEditLink)
            {
                Label lblEdit = e.Item.FindControl("lblEdit") as Label;
                lblEdit.Visible = false;
            }
        }
    }
}
