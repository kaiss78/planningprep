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
using App.Domain.Users;
using App.Models.Users;

public partial class Login : System.Web.UI.Page
{
    protected UserManager userManager = new UserManager();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        string userName = txtUserName.Text;
        string password = txtPassword.Text;

        PlanningPrepUser user = userManager.GetUserByUserNamePassword(userName, password);
        if (user != null)
        {
            SessionCache.CurrentUser = user;
            FormsAuthenticationUtil.RedirectFromLoginPage(userName, "", chkRememberMe.Checked);
        }
        else
        {
            //HtmlGenericControl divMessage = Login1.FindControl("divMessage") as HtmlGenericControl;
            AppUtil.ShowMessageBox(divMessage, "Your login attempt was not successful. Please try again.", true);
        }
    }
}
