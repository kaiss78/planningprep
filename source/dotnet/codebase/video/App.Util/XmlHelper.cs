using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Excel;
using System.IO;
using System.Xml;
using System.Web;

namespace App.Util
{
    public class XmlHelper
    {
        private StringWriter _StringWriter = null;
        private XmlTextWriter _XmlWriter = null;

        public XmlHelper()
        {


        }

        public static XmlHelper Instance
        {
            get
            {
                return new XmlHelper();
            }
        }

        private void CreateItemNode(VideoSectionItem item)
        {
            _XmlWriter.WriteRaw(String.Format(@"<item>
			            <title>{0}</title>
			            <media:content url='{1}' type='{2}' start='{3}' duration='4' />
			            <media:thumbnail url='{5}' />
			            <description>{6}</description>
			            <link>{7}/</link>
		            </item>", AppUtil.FilterChapterName(item.Chapter), GetVideoUrl(item.FileName)
                                , item.FileType, item.StartTime
                                , item.Duration, GetThumbNailUrl(item.ThumbNail)
                                , AppUtil.Encode(item.Description), item.Link));
        }

        private String GetVideoUrl(string fileName)
        {
            return String.Format("{0}/{1}", ConfigReader.VideoUrl, fileName);
        }

        private String GetThumbNailUrl(String fileName)
        {
            return String.Format("{0}/{1}", ConfigReader.ThumbnailUrl, fileName);
        }

        private String SaveXml(String xmlContent, string upperLevelChapterName, int level, string xmlDir)
        {
            //xmlDir = Path.Combine(xmlDir, Path.GetFileNameWithoutExtension((string)HttpContext.Current.Session["CURRENT_FILE"]));

            String fileName = string.Empty;
            Directory.CreateDirectory(xmlDir);
            try
            {
                fileName = String.Format("{0}.xml", upperLevelChapterName.Trim());
                string xmlFileName = Path.Combine(xmlDir, AppUtil.GetFilteredDiskFileName(fileName));
                File.AppendAllText(xmlFileName, xmlContent);
            }
            catch (Exception ex)
            {

            }
            return fileName;
        }

        private String SaveXml(String xmlContent, VideoSectionItem item, string xmlDir)
        {
            //xmlDir = Path.Combine(xmlDir, Path.GetFileNameWithoutExtension((string)HttpContext.Current.Session["CURRENT_FILE"]));

            String fileName = string.Empty;
            Directory.CreateDirectory(xmlDir);
            try
            {
                
                fileName = String.Format("{0}.xml", AppUtil.GetFilteredDiskFileName(item.Chapter));
                string xmlFileName = Path.Combine(xmlDir, AppUtil.GetFilteredDiskFileName(fileName));
                File.AppendAllText(xmlFileName, xmlContent);
            }
            catch (Exception ex)
            {

            }
            return fileName;
        }

       
             

        public void WriteXmlsForItems(string uppderLevelChapterName, string rootFolderName, List<VideoSectionItem> items, int level)
        {
            WriteXml(uppderLevelChapterName, rootFolderName, items, level);
            foreach (VideoSectionItem item in items)
            {
                if (item.ChildrenItems == null || item.ChildrenItems.Count == 0)
                {
                    WriteXml(uppderLevelChapterName, rootFolderName, item, level);
                }
            }
            foreach (VideoSectionItem item in items)
            {
                if (item.ChildrenItems != null)
                {
                    WriteXmlsForItems(item.Chapter, rootFolderName, item.ChildrenItems, level);
                }
            }
        }

        private void WriteXml(string upperLevelChapterName, string rootFolderName, List<VideoSectionItem> videoSectionItems, int level)
        {
            string xmlDir = Path.Combine(HttpContext.Current.Server.MapPath(ConfigReader.XmlDir), rootFolderName);
            //GenerateXmlfileForItems(items, level, uppderLevelChapterName, dir);

            if (videoSectionItems != null && videoSectionItems.Count > 0)
            {
                _StringWriter = new StringWriter();
                _XmlWriter = new XmlTextWriter(_StringWriter);
                _XmlWriter.Formatting = Formatting.Indented;

                _XmlWriter.WriteRaw("<rss version='2.0' xmlns:media='http://search.yahoo.com/mrss/'>");
                _XmlWriter.WriteRaw("<channel>");
                ///TODO: For now title is hard coded. It should be replaced.
                _XmlWriter.WriteRaw("<title>Test playlist with differents video</title>");

                foreach (VideoSectionItem item in videoSectionItems)
                {
                    CreateItemNode(item);
                }

                _XmlWriter.WriteRaw("</channel>");
                _XmlWriter.WriteRaw("</rss>");
                _XmlWriter.Flush();

                _StringWriter.Flush();
                String xmlFileName = SaveXml(_StringWriter.ToString(), upperLevelChapterName, level, xmlDir);


                _XmlWriter.Close();
            }
        }

        private void WriteXml(string upperLevelChapterName, string rootFolderName, VideoSectionItem videoSectionItem, int level)
        {
            string xmlDir = Path.Combine(HttpContext.Current.Server.MapPath(ConfigReader.XmlDir), rootFolderName);
            //GenerateXmlfileForItem(item, level, uppderLevelChapterName, dir);

            _StringWriter = new StringWriter();
            _XmlWriter = new XmlTextWriter(_StringWriter);
            _XmlWriter.Formatting = Formatting.Indented;

            _XmlWriter.WriteRaw("<rss version='2.0' xmlns:media='http://search.yahoo.com/mrss/'>");
            _XmlWriter.WriteRaw("<channel>");
            ///TODO: For now title is hard coded. It should be replaced.
            _XmlWriter.WriteRaw("<title>Test playlist with differents video</title>");


            CreateItemNode(videoSectionItem);


            _XmlWriter.WriteRaw("</channel>");
            _XmlWriter.WriteRaw("</rss>");
            _XmlWriter.Flush();

            _StringWriter.Flush();
            String xmlFileName = SaveXml(_StringWriter.ToString(), videoSectionItem, xmlDir);


            _XmlWriter.Close();
        }

        public void GenerateXmlfileForItem(VideoSectionItem videoSectionItem, int level, string upperLevelChapterName, string xmlDir)
        {
            
                
            
            ///TODO: Save Video File Information to the Database.
        }


        public void GenerateXmlfileForItems(List<VideoSectionItem> videoSectionItems, int level, string upperLevelChapterName, string xmlDir)
        {
            
            ///TODO: Save Video File Information to the Database.
        }

    }
}
