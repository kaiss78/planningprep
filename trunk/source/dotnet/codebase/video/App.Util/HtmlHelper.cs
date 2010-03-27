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

        public void WriteResponseForItems(List<VideoSectionItem> items, ChapterDefinitionFile file)
        {
            HttpContext.Current.Response.Clear();
            StringBuilder sb = new StringBuilder();

            foreach (VideoSectionItem item in items)
            {
                WriteHTMLForDataForItem(item, sb, file);
            }

            HttpContext.Current.Response.Write(sb.ToString());
        }

        private void WriteHTMLForDataForItem(VideoSectionItem item, StringBuilder sb, ChapterDefinitionFile file)
        {
            if (item.ChildrenItems != null && item.ChildrenItems.Count > 0)
            {
                sb.Append("<div class=\"expandCollapseDivWrapper\">");
                sb.AppendFormat("<div wrapperId={0} class=\"expandCollapseDiv\">+</div>", item.Number);
                sb.AppendFormat("<div onclick=\"runVideo('{0}')\" class=\"chapterDivWithExpandCollapse\">", AppUtil.GetXmlUrlForItem(item,file));
                sb.Append(AppUtil.FilterChapterName(item.Chapter));
                sb.Append("</div>");
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
                sb.AppendFormat("<div onclick=\"runVideo('{0}')\" class=\"singleItem\">", AppUtil.GetXmlUrlForItem(item,file));

                sb.Append(AppUtil.FilterChapterName(item.Chapter));

                sb.Append("</div>");
            }
        }
    }
}
