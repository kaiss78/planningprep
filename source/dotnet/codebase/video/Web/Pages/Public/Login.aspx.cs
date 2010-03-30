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
using App.Data;
using App.Domain;
using App.Util;

public partial class Pages_Public_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Login");
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            LoginUser();
        }
    }

    protected void LoginUser()
    {
        UserManager manager = new UserManager();
        SiteUser user = manager.GetByUserByEmail(txtEmailId.Text.Trim());
        if (user == null)
            AppUtil.ShowMessage(divMessageBox, "Sorry! Your Email Id does not exist.", true);
        else
        {
            SessionCache.CurrentUser = user;
        }
    }
}
