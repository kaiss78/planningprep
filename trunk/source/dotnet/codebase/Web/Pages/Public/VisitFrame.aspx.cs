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

public partial class Pages_Public_VisitFrame : System.Web.UI.Page
{
    protected String _ExternalLink = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        _ExternalLink = Server.UrlDecode(Request[AppConstants.QueryString.LINK]);
    }
}
