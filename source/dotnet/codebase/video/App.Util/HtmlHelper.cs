using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using App.Data;

namespace App.Util
{
    public class HtmlHelper
    {
        public static HtmlHelper Instance
        {
            get
            {
                return new HtmlHelper();
            }
        }

        public string GetResponseForItems(List<VideoSectionItem> items, ChapterDefinitionFile file)
        {
            HttpContext.Current.Response.Clear();
            StringBuilder sb = new StringBuilder();

            foreach (VideoSectionItem item in items)
            {
                WriteHTMLForDataForItem(item, sb, file);
            }

            return sb.ToString();
        }

        private string GetMinuteSecond(string durationInSeconds)
        {
            int seconds = (int)Convert.ToSingle(durationInSeconds);
            int minutes = seconds / 60;
            int secondsAfterMinute = seconds % 60;

            string strMinutes = minutes < 10 ? string.Format("0{0}", minutes) : minutes.ToString();
            string strSeconds = secondsAfterMinute < 10 ? string.Format("0{0}", secondsAfterMinute) : secondsAfterMinute.ToString();
            return string.Format("{0}:{1}", strMinutes, strSeconds);
        }

        private void WriteHTMLForDataForItem(VideoSectionItem item, StringBuilder sb, ChapterDefinitionFile file)
        {
            if (item.ChildrenItems != null && item.ChildrenItems.Count > 0)
            {
                sb.Append("<div class=\"expandCollapseDivWrapper\">");
                sb.AppendFormat("<div wrapperId={0} class=\"expandCollapseDiv\">+</div>", item.Number);
                sb.AppendFormat("<div onclick=\"runVideo('{0}','{1}')\" class=\"chapterDivWithExpandCollapse\">", AppUtil.GetXmlUrlForItem(item,file.FileName),item.Number);
                sb.Append(AppUtil.FilterChapterName(item.Chapter));
                sb.Append("</div>");
                sb.AppendFormat("<div style=\"float:right;\">{0}</div>", GetMinuteSecond(item.Duration));
                sb.Append("<div class=\"clearBoth\"></div>");
                sb.Append("</div>");

                sb.AppendFormat("<div childrenId={0} class=\"chapterDivWithoutExpandCollapse\">", item.Number);
                foreach (VideoSectionItem childItem in item.ChildrenItems)
                {
                    WriteHTMLForDataForItem(childItem, sb, file);
                }
                sb.Append("</div>");
                
            }
            else
            {
                sb.AppendFormat("<div onclick=\"runVideo('{0}','{1}')\" class=\"singleItem\">", AppUtil.GetXmlUrlForItem(item, file.FileName),item.Number);

                sb.Append(AppUtil.FilterChapterName(item.Chapter));
                sb.AppendFormat("<div style=\"float:right;\">{0}</div>", GetMinuteSecond(item.Duration));
                sb.Append("</div>");

            }
        }
    }
}
