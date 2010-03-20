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

public partial class Pages_Public_JoinOutcome : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Membership Successfully Processed");
        if (!Page.IsPostBack)
        {
            Page.Form.Action = "https://www.paypal.com/cgi-bin/webscr";
            Page.Form.Method = "post";
        }
    }
}
