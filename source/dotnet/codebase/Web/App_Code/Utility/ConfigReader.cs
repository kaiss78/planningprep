﻿using System;
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
    private const String ADMIN_QUESTION_LIST_SIZE = "AdminQuestionListSize";
    private const String ADMIN_EMAIL = "AdminEmail";
    private const String SMTP_HOST = "SmtpHost";
    private const String SMTP_PORT = "SmtpPort";


    private const String _ExamLengthInMinutes = "ExamLengthInMinutes";
    private static String GetAppSettingsValue(String key)
    {
        return ConfigurationManager.AppSettings[key];
    }
         
    public static int AdminQuestionListSize
    {
        get
        {
            int pageSize = 0;
            String paramValue = GetAppSettingsValue(ADMIN_QUESTION_LIST_SIZE);
            int.TryParse(paramValue, out pageSize);
            return pageSize;
        }
    }


    public static int ExamLengthInMinutes
    {
        get
        {
            int configValue = 0;
            String paramValue = GetAppSettingsValue(_ExamLengthInMinutes);
            int.TryParse(paramValue, out configValue);
            return configValue;
        }
    }

    public static String AdminEmail
    {
        get
        {
            return GetAppSettingsValue(ADMIN_EMAIL);
        }
    }
    public static String SmtpHost
    {
        get
        {
            return GetAppSettingsValue(SMTP_HOST);
        }
    }
    /// <summary>
    /// Get the Configuration Value for SMTP port. If not specified then retuns a default value of 25
    /// </summary>
    public static int SmtpPort
    {
        get
        {
            int port = 0;
            String paramValue = GetAppSettingsValue(SMTP_PORT);
            int.TryParse(paramValue, out port);
            return port == 0 ? 25 : port;
        }
    }

}