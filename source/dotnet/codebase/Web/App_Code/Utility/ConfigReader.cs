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

/// <summary>
/// Summary description for ConfigReader
/// </summary>
public class ConfigReader
{
    private const String _AdminQuestionListSize = "AdminQuestionListSize";
    private static String GetAppSettingsValue(String key)
    {
        return ConfigurationManager.AppSettings[key];
    }
         
    public static int AdminQuestionListSize
    {
        get
        {
            int pageSize = 0;
            String paramValue = GetAppSettingsValue(_AdminQuestionListSize);
            int.TryParse(paramValue, out pageSize);
            return pageSize;
        }
    }
}
