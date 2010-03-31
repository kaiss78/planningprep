using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using App.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for AppUtil
/// </summary>

namespace App.Util
{
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
        public static string GetPageTitle(string title)
        {
            return string.Format("MedStudy : {0}", title);
        }
        public static string Encode(String text)
        {
            return HttpUtility.HtmlEncode(text);
        }
        public static string FormatText(String text)
        {
            return Encode(text).Replace(Environment.NewLine, "<br />").Replace("\n", "<br />");
        }
        public static String ReadEmailTemplate(String templateFileName)
        {
            String filePath = HttpContext.Current.Server.MapPath(AppConstants.Directories.EMAIL_TEMPLATE);
            filePath = Path.Combine(filePath, templateFileName);
            return File.ReadAllText(filePath);
        }
        public static String GetDomainAddress()
        {
            return String.Format("http://{0}/", HttpContext.Current.Request.Url.Host);
        }
        /// <summary>
        /// Gets the IP address of the remote user.
        /// </summary>
        /// <returns></returns>
        public static string GetRemoteIPAddress()
        {
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
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
        /// Gets the request param value in string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetRequestParamValueInString(string key)
        {
            string paramValue = HttpContext.Current.Request[key];
            return paramValue;
        }

        public static string FilterChapterName(string chapter)
        {
            chapter = chapter.Trim();
            chapter = chapter.Trim('-');
            chapter = chapter.Trim();
            return chapter;
        }

        public static string GetFilteredDiskFileName(string fileName)
        {
            fileName = FilterChapterName(fileName);
            return fileName.Replace(":", "_").Replace(" ", "_").Replace("/", "_").Replace(@"\", "");
        }

        public static string GetXmlUrlForItem(VideoSectionItem item,string fileName)
        {
            string path = string.Format("{0}/{1}/{2}.xml", ConfigReader.XmlUrl, Path.GetFileNameWithoutExtension(fileName), GetFilteredDiskFileName(item.Chapter));
            return path;
        }

        public static void ShowMessage(HtmlGenericControl divMessageBox, String message, bool isError)
        {
            if (isError)
                divMessageBox.Attributes["class"] = "ErrorMessageBox";
            else
                divMessageBox.Attributes["class"] = "MessageBox";
            divMessageBox.InnerHtml = message;
            divMessageBox.Visible = true;
        }

        public static string GetUploadFolderForExel()
        {
            return Path.Combine(HttpContext.Current.Server.MapPath(@"~\"), ConfigReader.InputExel);
        }

        public static string GetUploadFolderForXml()
        {
            return Path.Combine(HttpContext.Current.Server.MapPath(@"~\"), ConfigReader.XmlDir);
        }
    }
}
