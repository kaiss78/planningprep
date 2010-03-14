using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
//using DAL;
using System.Collections.Generic;
using System.IO;
using System.Collections;

/// <summary>
/// Summary description for AppUtil
/// </summary>
public class AppUtil
{
    public static DateTime SqlDateTimeMinValue
    {
        get { return new DateTime(1753, 1, 1); }
    }
    public static DateTime SqlDateTimeMaxValue
    {
        get { return new DateTime(9999, 12, 31); }
    }

    /// <summary>
    /// Creates the JavaScript Calendar Object for a Page
    /// </summary>
    /// <param name="page"></param>
    /// <param name="textBoxClientId"></param>
    /// <param name="buttonId"></param>
    public static void CreateJSCalendar(Page page, string textBoxClientId, string buttonId)
    {
        ScriptManager.RegisterStartupScript(page, page.GetType(), Guid.NewGuid().ToString(), string.Format("CreateCalender('{0}', '{1}');", textBoxClientId, buttonId), true);
    }
    public static string GetPageTitle(string title)
    {
        return string.Format("PlanningPrep : {0}", title);
    }
    public static string Encode(String text)
    {
        return HttpContext.Current.Server.HtmlEncode(text);
    }
    /// <summary>
    /// Gets Cookie from the Current Http Request
    /// </summary>
    /// <param name="key"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static String GetCookie(string key)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[AppConstants.Cookie.BASE];
        if (cookie != null)
        {
            if (string.IsNullOrEmpty(cookie[key]))
                return string.Empty;

            return cookie[key];
        }
        return String.Empty;

        //String value = HttpContext.Current.Request.Cookies[AppConstants.Cookie.BASE][key];
        //return value;
    }
    /// <summary>
    /// Sets Cookie to the Current Http Response
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="response"></param>
    public static void SetCookie(string key, string value)
    {
        HttpCookie cookie = null;
        //if (HttpContext.Current.Request.Cookies[AppConstants.Cookie.BASE] == null)
        {
            cookie = new HttpCookie(AppConstants.Cookie.BASE);
            //HttpContext.Current.Response.Cookies.Add(cookie);
        }
        //cookie = HttpContext.Current.Request.Cookies[AppConstants.Cookie.BASE];
        cookie[key] = value;
        cookie.Expires = DateTime.Now.AddYears(1);
        HttpContext.Current.Response.Cookies.Add(cookie);
        
        
            

        //HttpContext.Current.Response.Cookies[AppConstants.Cookie.BASE][key] = value;        
        //HttpContext.Current.Response.Cookies[AppConstants.Cookie.BASE].Expires = DateTime.Now.AddYears(1);

    }    
    
    /// <summary>
    /// Builds a DateTime Object from a BD Format Date. (24/10/2009)
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime GetDate(string date)
    {
        if (date.IndexOf("/") > -1)
        {
            try
            {
                string[] parts = date.Split('/');
                DateTime newDate = new DateTime(Convert.ToInt32(parts[2]), Convert.ToInt32(parts[1]), Convert.ToInt32(parts[0]));
                return newDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return DateTime.MinValue;
    }

    public static bool IsValidImageFile(HttpPostedFile httpPostedFile)
    {
        if (httpPostedFile.ContentLength > 0)
        {
            string extension = Path.GetExtension(httpPostedFile.FileName);
            return IsValidImageFileExtension(extension);
        }
        return false;
    }
    private static bool IsValidImageFileExtension(string extension)
    {
        if (String.Compare(extension, ".jpg", true) == 0)
            return true;
        else if (String.Compare(extension, ".jpeg", true) == 0)
            return true;
        else if (String.Compare(extension, ".gif", true) == 0)
            return true;
        else if (String.Compare(extension, ".png", true) == 0)
            return true;
        return false;
    }    
    public static void ShowMessageBox(HtmlGenericControl divMessage, string message, bool isErrorMessage)
    {
        divMessage.InnerHtml = message;
        divMessage.Attributes["class"] = isErrorMessage ? AppConstants.UI.ERROR_MESSAGE_BOX_CLASS : AppConstants.UI.MESSAGE_BOX_CLASS;
        divMessage.Visible = true;
    }
    public static string FormatDate(object date)
    {
        return Convert.ToDateTime(date).ToString(AppConstants.ValueOf.DATE_FROMAT_DISPLAY);
    }    

    /// <summary>
    /// Gets the first day of month.
    /// </summary>
    /// <param name="givenDate">The given date.</param>
    /// <returns>the first day of the month</returns>
    public static DateTime GetFirstDayOfMonth(DateTime givenDate)
    {
        return new DateTime(givenDate.Year, givenDate.Month, 1);
    }

    /// <summary>
    /// Gets the last day of month.
    /// </summary>
    /// <param name="givenDate">The given date.</param>
    /// <returns>the last day of the month</returns>
    public static DateTime GetLastDayOfMonth(DateTime givenDate)
    {
        return GetFirstDayOfMonth(givenDate).AddMonths(1).Subtract(new TimeSpan(1, 0, 0, 0, 0));
    }
    public static string GetMonthString(int month)
    {
        switch (month)
        {
            case 1:
                return "January";
            case 2:
                return "February";
            case 3:
                return "March";
            case 4:
                return "April";
            case 5:
                return "May";
            case 6:
                return "June";
            case 7:
                return "July";
            case 8:
                return "August";
            case 9:
                return "September";
            case 10:
                return "October";
            case 11:
                return "November";
            case 12:
                return "December";
            default:
                return string.Empty;
        }
    }

    /// <summary>
    /// Checks that the Currently Loged In user has an specific role permission
    /// </summary>
    /// <param name="roleList"></param>
    /// <returns></returns>
    public static bool IsUserPermitted(ArrayList roleList)
    {
        return IsUserPermitted((string[])roleList.ToArray(typeof(string)));
    }
    /// <summary>
    /// Checks that the Currently Loged In user has an specific role permission
    /// </summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public static bool IsUserPermitted(string[] roleNames)
    {
        foreach (string role in roleNames)
        {
            if (string.Compare(role, "*", true) == 0)
                return true;
            if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, role))
                return true;
        }
        return false;
    }
    /// <summary>
    /// Checks that the currently logged in user has a specific role's permission
    /// </summary>
    /// <param name="roleName"></param>
    /// <returns></returns>
    public static bool IsUserPermitted(string roleName)
    {
        if (!string.IsNullOrEmpty(roleName))
        {
            if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, roleName))
                return true;
        }
        return false;
    }
    public static String ReadEmailTemplate(String templateFileName)
    {
        String filePath = HttpContext.Current.Server.MapPath("/EmailTemplates");
        filePath = Path.Combine(filePath, templateFileName);
        return File.ReadAllText(filePath);
    }
    public static String GetDomainAddress()
    {
        return String.Format("http://{0}/", HttpContext.Current.Request.Url.Host);
    }
    public static String GetContentDetailsUrl(int contentId)
    {
        return String.Format("{0}?{1}={2}", AppConstants.Pages.SHOW_CONTENT, AppConstants.QueryString.ID, contentId);
    }
}
