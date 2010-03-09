#region References

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Text;
using System.IO;
using System.Data;
using App.Models.Users;
using App.Domain.Users;


#endregion

#region Class

/// <summary>
/// Summary description for WebUtil
/// </summary>
public class WebUtil
{
    public WebUtil()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Signouts the user.
    /// </summary>
    public static void SignoutUser()
    {
        SessionCache.ClearSession();
        FormsAuthentication.SignOut();
        HttpContext.Current.Response.Redirect(FormsAuthentication.LoginUrl);
    }

    /// <summary>
    /// Logins the user.
    /// </summary>
    public static void LoginUser()
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated && SessionCache.CurrentUser == null)
        {
            string userName = HttpContext.Current.User.Identity.Name;

            UserManager manager = new UserManager();
            PlanningPrepUser oplmUser = manager.GetUserByUserName(userName);
            if (oplmUser != null)
            {
                SessionCache.CurrentUser = oplmUser;    
            }
        }
    }
    
    #endregion
}
