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
using App.Util;
using App.Domain;
using App.Data;

public partial class Pages_Public_ActivateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = AppUtil.GetPageTitle("Activate Account");
        if (!IsPostBack)
        {
            ActivateAccount();
        }
    }

    private void ActivateAccount()
    {
        String key = Request[AppConstants.UrlParams.KEY];
        if (!String.IsNullOrEmpty(key))
        {
            UserManager userManager = new UserManager();
            SiteUser user = userManager.GetUserByActivationKey(key);
            if(user == null)
            {
                AppUtil.ShowMessage(divMessage, "Sorry! we could not find your activation key.", true);
            }
            else
            {
                if (user.IsActive)
                {
                    AppUtil.ShowMessage(divMessage, "Sorry! your account is already activated.", true);
                }
                else
                {
                    user.IsActive = true;
                    userManager.Save(user);
                    AppUtil.ShowMessage(divMessage, "Thanks! your account has been activated successfully.", false);
                }
            }
        }
        else
        {
            AppUtil.ShowMessage(divMessage, "Sorry! we could not find your activation key.", true);
        }
    }
}
