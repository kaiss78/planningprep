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

public partial class UserControls_PublicMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if(SessionCache.CurrentUser != null)
        {
            hplLogin.NavigateUrl = "/Login.aspx?Logout=True";
            hplLogin.Text = "Log Out";
        }
    }
}
