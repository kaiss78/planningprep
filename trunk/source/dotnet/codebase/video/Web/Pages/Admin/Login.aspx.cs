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

public partial class Pages_Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Login");

        if (Request["Action"] == "Logout")
        {
            SessionCache.ClearSession();
            FormsAuthentication.SignOut();
        }
        Response.Redirect(string.Format(@"~\Login.aspx?ReturnUrl={0}/Pages/Admin/UploadFile.aspx",HttpContext.Current.Request.ApplicationPath));
    }
}
