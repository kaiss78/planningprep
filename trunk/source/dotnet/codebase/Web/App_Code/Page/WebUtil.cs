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
    /// Gets the request param value in long.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public static long GetRequestParamValueInLong(string key)
    {
        long paramValue = 0;
        long.TryParse(HttpContext.Current.Request[key], out paramValue);

        return paramValue;
    }

    /// <summary>
    /// Gets the request param value in byte.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public static byte GetRequestParamValueInByte(string key)
    {
        byte paramValue = 0;
        byte.TryParse(HttpContext.Current.Request[key], out paramValue);

        return paramValue;
    }

    /// <summary>
    /// Gets the request param value in int.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns></returns>
    public static int GetRequestParamValueInInt(string key)
    {
        int paramValue = 0;
        int.TryParse(HttpContext.Current.Request[key], out paramValue);

        return paramValue;
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
    

    
    public static string GetExamKeyForExamType(int ExamID)
    {
        return string.Format("EXAM_{0}",ExamID);
    }
    #endregion
}
