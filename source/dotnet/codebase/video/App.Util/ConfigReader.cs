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

namespace App.Util
{
    public class ConfigReader
    {
        private const String XML_DIR = "XmlDir";
        private const String INPUT_EXEL = "InputExel";
        private const String VIDEO_DIR = "VideoDir";
        private const String THUMBNAIL_DIR = "ThumbnailDir";
        private const String THUMBNAIL_URL = "ThumbnailUrl";
        private const String VIDEO_URL = "VideoUrl";
        private const String SITE_URL = "SiteUrl";
        private const String CONNECTION_STRING = "SiteConnectionString";
      
        private static String GetAppSettingsValue(String key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static String XmlDir
        {
            get
            {
                return GetAppSettingsValue(XML_DIR);
            }
        }

        public static String InputExel
        {
            get
            {
                return GetAppSettingsValue(INPUT_EXEL);
            }
        }

        public static String ThumbnailUrl
        {
            get
            {
                return string.Format("{0}/{1}",SiteUrl, ThumbnailDir);
            }
        }

        public static String ThumbnailDir
        {
            get
            {
                return GetAppSettingsValue(THUMBNAIL_DIR);
            }
        }

        public static String VideoDir
        {
            get
            {
                return GetAppSettingsValue(VIDEO_DIR);
            }
        }

        public static String VideoUrl
        {
            get
            {
                return string.Format("{0}/{1}",SiteUrl, VideoDir);
            }
        }

        public static String XmlUrl
        {
            get
            {
                return string.Format("{0}/{1}", SiteUrl, XmlDir);
            }
        }

        public static String SiteUrl
        {
            get
            {
                return GetAppSettingsValue(SITE_URL);
            }
        }

        public static String ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[CONNECTION_STRING].ConnectionString;
            }
        }
       
    }
}
