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

public partial class UserControls_PublicMenu : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if(SessionCache.CurrentUser != null)
        {
            hplLogin.NavigateUrl = String.Format("/Login.aspx?{0}=True", AppConstants.QueryString.LOG_OUT);
            hplLogin.Text = "Log Out";
        }
    }
}
