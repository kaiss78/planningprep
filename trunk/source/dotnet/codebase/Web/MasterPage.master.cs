using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Pages_MasterPage : System.Web.UI.MasterPage
{
    protected bool _IsAdministrator = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionCache.CurrentUser != null)
        {
            HtmlMeta metaDescription = header.FindControl("metaDescription") as HtmlMeta;
            HtmlMeta metaKeywords = header.FindControl("metaKeywords") as HtmlMeta;
            metaDescription.Visible = false;
            metaKeywords.Visible = false;
        }
    }
    protected bool IsAdministrator()
    {
        if (SessionCache.CurrentUser != null)
        {
            if (String.Compare(SessionCache.CurrentUser.Rights, AppConstants.UserRoles.ADMINISTRATOR, true) == 0)
                return true;
        }
        return false;
    }

    
}
