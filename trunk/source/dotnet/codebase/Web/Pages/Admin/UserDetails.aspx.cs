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

public partial class Pages_Admin_UserDetails : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadUserProfile();
    }
    protected void LoadUserProfile()
    {
        int UserID = WebUtil.GetRequestParamValueInInt(AppConstants.QueryString.USER_ID);
        if (UserID > 0)
        {
            ucUserProfile.UserID = UserID;
        }
    }
}
