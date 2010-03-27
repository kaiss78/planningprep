﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using App.Data;

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
            String filePath = HttpContext.Current.Server.MapPath("/EmailTemplates");
            filePath = Path.Combine(filePath, templateFileName);
            return File.ReadAllText(filePath);
        }
        public static String GetDomainAddress()
        {
            return String.Format("http://{0}/", HttpContext.Current.Request.Url.Host);
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

        public static string GetXmlUrlForItem(VideoSectionItem item, ChapterDefinitionFile file)
        {
            string path = string.Format("{0}/{1}/{2}.xml",ConfigReader.XmlUrl,Path.GetFileNameWithoutExtension(file.FileName), GetFilteredDiskFileName(item.Chapter));
            return path;
        }
    }
}
